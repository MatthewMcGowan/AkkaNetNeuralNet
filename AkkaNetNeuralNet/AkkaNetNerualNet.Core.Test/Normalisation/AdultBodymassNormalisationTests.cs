using System.Collections.Generic;
using System.Linq;
using AkkaNetNerualNet.Core.Test.TestData;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;
using AkkaNetNeuralNet.Core.Normalisation;
using NUnit.Framework;

namespace AkkaNetNerualNet.Core.Test.Normalisation
{
    [TestFixture]
    public class AdultBodymassNormalisationTests
    {
        private IEnumerable<DogProfile> _data;

        [SetUp]
        public void SetUp()
        {
            _data = DogProfileTestData.GetTestDogProfiles();
        }

        [Test]
        public void NormaliseMasses_ReturnsSameNumberOfInputRecords()
        {
            var result = _data.NormaliseMasses();

            Assert.AreEqual(_data.Count(), result.Count());
        }

        [Test]
        public void NormaliseMasses_ReturnsOtherFieldsUnmodified()
        {
            var result = _data.NormaliseMasses();

            bool OtherFieldEquality(DogProfile x, DogProfile y) =>
                x.AgeAtDeath == y.AgeAtDeath &&
                x.Sex == y.Sex &&
                x.HouseholdIncome == y.HouseholdIncome &&
                x.Locale == y.Locale;

            Assert.IsTrue(_data.All(d => result.Any(r => OtherFieldEquality(d, r))));
        }

        [Test]
        public void NormaliseMasses_MinCorrectlyNormalised()
        {
            decimal minAge = _data.NormaliseMasses().ToList()[0].AdultBodymass;

            Assert.AreEqual(0, minAge);
        }

        [Test]
        public void NormaliseMasses_MaxCorrectlyNormalised()
        {
            decimal maxAge = _data.NormaliseMasses().ToList()[2].AdultBodymass;

            Assert.AreEqual(1, maxAge);
        }

        [Test]
        public void NormaliseMasses_IntermediateCorrectlyNormalised()
        {
            decimal age = _data.NormaliseMasses().ToList()[1].AdultBodymass;

            Assert.AreEqual(0.25, age);
        }

        /// <summary>
        /// If Min == Max, divide by zero error.
        /// What this really means though is all data has same value, so not useful for prediction.
        /// </summary>
        [Test]
        public void NormaliseMasses_AllAgesAreSameValue_NormaliseToHalf()
        {
            var result = _data.Select(x => DogProfileHelpers.UpdateAdultBodyMass(x, 2m)).NormaliseMasses();

            Assert.IsTrue(result.All(x => x.AdultBodymass == 0.5m));
        }
    }
}
