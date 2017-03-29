using System.Linq;
using AkkaNetNerualNet.Core.Test.TestData;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;
using NUnit.Framework;

namespace AkkaNetNerualNet.Core.Test.Helpers
{
    [TestFixture]
    public class DogProfileHelpersTests
    {
        private DogProfile _original;

        [SetUp]
        public void SetUp()
        {
            _original = DogProfileTestData.GetTestDogProfiles().First();
            
        }

        [Test]
        public void UpdateAgeAtDeath_CorrectlyUpdatesValue()
        {
            var updated = DogProfileHelpers.UpdateAgeAtDeath(_original, 100);

            Assert.AreEqual(100, updated.AgeAtDeath);
        }

        [Test]
        public void UpdateAgeAtDeath_OtherValuesUnaffected()
        {
            var updated = DogProfileHelpers.UpdateAgeAtDeath(_original, 100);

            Assert.AreEqual(_original.Sex, updated.Sex);
            Assert.AreEqual(_original.Locale, updated.Locale);
            Assert.AreEqual(_original.AdultBodymass, updated.AdultBodymass);
            Assert.AreEqual(_original.HouseholdIncome, updated.HouseholdIncome);
        }

        /// <summary>
        /// Perhaps a silly test, but documents.
        /// </summary>
        [Test]
        public void UpdateAgeAtDeath_OriginalObjectNotMutated()
        {
            decimal originalAge = _original.AgeAtDeath;

            var updated = DogProfileHelpers.UpdateAgeAtDeath(_original, 100);

            Assert.AreEqual(originalAge, _original.AgeAtDeath);
        }
    }
}
