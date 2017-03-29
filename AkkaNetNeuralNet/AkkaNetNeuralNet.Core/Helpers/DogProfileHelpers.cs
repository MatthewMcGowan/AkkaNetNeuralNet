using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Helpers
{
    public static class DogProfileHelpers
    {
        public static DogProfile UpdateAgeAtDeath(DogProfile dogProfile, decimal updatedValue)
        {
            return new DogProfile(updatedValue, dogProfile.Sex, dogProfile.Breed, dogProfile.AdultBodymass,
                dogProfile.HouseholdIncome);
        }

        public static DogProfile UpdateAdultBodyMass(DogProfile dogProfile, decimal updatedValue)
        {
            return new DogProfile(dogProfile.AgeAtDeath, dogProfile.Sex, dogProfile.Breed, updatedValue, dogProfile.HouseholdIncome);
        }
    }
}
