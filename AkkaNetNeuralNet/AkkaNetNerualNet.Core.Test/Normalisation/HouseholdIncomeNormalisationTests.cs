using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkkaNetNerualNet.Core.Test.TestData;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;
using AkkaNetNeuralNet.Core.Normalisation;
using NUnit.Framework;

namespace AkkaNetNerualNet.Core.Test.Normalisation
{
    [TestFixture]
    public class HouseholdIncomeNormalisationTests
    {
        private IEnumerable<DogProfile> _data;

        [SetUp]
        public void SetUp()
        {
            _data = DogProfileTestData.GetTestDogProfiles();
        }

        [Test]
        public void NormaliseIncomess_ReturnsSameNumberOfInputRecords()
        {
            var result = _data.NormaliseIncomes();

            Assert.AreEqual(_data.Count(), result.Count());
        }

        [Test]
        public void NormaliseIncomes_ReturnsOtherFieldsUnmodified()
        {
            var result = _data.NormaliseIncomes();

            bool OtherFieldEquality(DogProfile x, DogProfile y) =>
                x.AgeAtDeath == y.AgeAtDeath &&
                x.Sex == y.Sex &&
                x.AdultBodymass == y.AdultBodymass &&
                x.Breed == y.Breed;

            Assert.IsTrue(_data.All(d => result.Any(r => OtherFieldEquality(d, r))));
        }

        [Test]
        public void NormaliseIncomes_MinCorrectlyNormalised()
        {
            decimal minAge = _data.NormaliseIncomes().ToList()[0].HouseholdIncome;

            Assert.AreEqual(0, minAge);
        }

        [Test]
        public void NormaliseIncomes_MaxCorrectlyNormalised()
        {
            decimal maxAge = _data.NormaliseIncomes().ToList()[2].HouseholdIncome;

            Assert.AreEqual(1, maxAge);
        }

        [Test]
        public void NormaliseIncomes_IntermediateCorrectlyNormalised()
        {
            decimal age = _data.NormaliseIncomes().ToList()[1].HouseholdIncome;

            Assert.AreEqual(0.25, age);
        }

        /// <summary>
        /// If Min == Max, divide by zero error.
        /// What this really means though is all data has same value, so not useful for prediction.
        /// </summary>
        [Test]
        public void NormaliseIncomes_AllAgesAreSameValue_NormaliseToHalf()
        {
            var result = _data.Select(x => DogProfileHelpers.UpdateHouseholdIncome(x, 2m)).NormaliseIncomes();

            Assert.IsTrue(result.All(x => x.HouseholdIncome == 0.5m));
        }
    }
}
