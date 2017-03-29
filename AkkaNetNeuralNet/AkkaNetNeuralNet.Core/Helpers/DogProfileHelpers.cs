using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Helpers
{
    public static class DogProfileHelpers
    {
        public static DogProfile UpdateAgeAtDeath(DogProfile dogProfile, decimal updatedValue)
        {
            return new DogProfile(updatedValue, dogProfile.Sex, dogProfile.Locale, dogProfile.AdultBodymass,
                dogProfile.HouseholdIncome);
        }
    }
}
