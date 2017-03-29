using System.Linq;
using AkkaNetNerualNet.Core.Test.TestData;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;
using NUnit.Framework;

namespace AkkaNetNerualNet.Core.Test.Helpers
{
    /// <summary>
    /// Note: This approach results in a lot of testing boilerplate. 
    /// Should figure out a way to refactor this without using a bunch of reflection.
    /// </summary>
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
            Assert.AreEqual(_original.Breed, updated.Breed);
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

        [Test]
        public void UpdateAdultBodyMass_CorrectlyUpdatesValue()
        {
            var updated = DogProfileHelpers.UpdateAdultBodyMass(_original, 100);

            Assert.AreEqual(100, updated.AdultBodymass);
        }

        [Test]
        public void UpdateAdultBodyMass_OtherValuesUnaffected()
        {
            var updated = DogProfileHelpers.UpdateAdultBodyMass(_original, 100);

            Assert.AreEqual(_original.AgeAtDeath, updated.AgeAtDeath);
            Assert.AreEqual(_original.Sex, updated.Sex);
            Assert.AreEqual(_original.Breed, updated.Breed);
            Assert.AreEqual(_original.HouseholdIncome, updated.HouseholdIncome);
        }

        /// <summary>
        /// Perhaps a silly test, but documents.
        /// </summary>
        [Test]
        public void UpdateAdultBodyMass_OriginalObjectNotMutated()
        {
            decimal originalMass = _original.AdultBodymass;

            var updated = DogProfileHelpers.UpdateAdultBodyMass(_original, 100);

            Assert.AreEqual(originalMass, _original.AdultBodymass);
        }
    }
}
