using System.Collections.Generic;
using System.Linq;
using AkkaNetNerualNet.Core.Test.TestData;
using AkkaNetNeuralNet.Core.Model;
using AkkaNetNeuralNet.Core.Normalisation;
using NUnit.Framework;

using D = AkkaNetNeuralNet.Core.Helpers.DogProfileHelpers;

namespace AkkaNetNerualNet.Core.Test.Normalisation
{
    [TestFixture]
    public class AgeAtDeathNormalisationTests
    {
        private IEnumerable<DogProfile> _data;

        [SetUp]
        public void SetUp()
        {
            _data = DogProfileTestData.GetTestDogProfiles();
        }

        [Test]
        public void NormaliseAges_ReturnsSameNumberOfInputRecords()
        {
            var result = _data.NormaliseAges();

            Assert.AreEqual(_data.Count(), result.Count());
        }

        [Test]
        public void NormaliseAges_ReturnsOtherFieldsUnmodified()
        {
            var result = _data.NormaliseAges();

            bool OtherFieldEquality(DogProfile x, DogProfile y) =>
                x.Sex == y.Sex &&
                x.AdultBodymass == y.AdultBodymass &&
                x.HouseholdIncome == y.HouseholdIncome &&
                x.Locale == y.Locale;

            Assert.IsTrue(_data.All(d => result.Any(r => OtherFieldEquality(d, r))));
        }

        [Test]
        public void NormaliseAges_MinCorrectlyNormalised()
        {
            decimal minAge = _data.NormaliseAges().ToList()[0].AgeAtDeath;

            Assert.AreEqual(0, minAge);
        }

        [Test]
        public void NormaliseAges_MaxCorrectlyNormalised()
        {
            decimal maxAge = _data.NormaliseAges().ToList()[2].AgeAtDeath;

            Assert.AreEqual(1, maxAge);
        }

        [Test]
        public void NormaliseAges_IntermediateCorrectlyNormalised()
        {
            decimal age = _data.NormaliseAges().ToList()[1].AgeAtDeath;

            Assert.AreEqual(0.25, age);
        }

        /// <summary>
        /// If Min == Max, divide by zero error.
        /// What this really means though is all data has same value, so not useful for prediction.
        /// //TODO Consider how to handle this case, given this is the dependent variable.
        /// </summary>
        [Test]
        public void NormaliseAges_AllAgesAreSameValue_NormaliseToHalf()
        {
            var result = _data.Select(x => D.UpdateAgeAtDeath(x, 2m)).NormaliseAges();

            Assert.IsTrue(result.All(x => x.AgeAtDeath == 0.5m));
        }
    }
}
