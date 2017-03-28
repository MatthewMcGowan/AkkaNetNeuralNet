using AkkaNetNeuralNet.Core.Model;
using System.Collections.Generic;

namespace AkkaNetNeuralNet.Console
{
    public static class DummySource
    {
        public static IEnumerable<DogProfile> GetTrainingData()
        {
            return new List<DogProfile>
            {
                new DogProfile{AgeAtDeath = 7, Sex = Sex.Male, Locale = Locale.Suburban, AdultBodymass = 120.2m, HouseholdIncome = 64000},
                new DogProfile{AgeAtDeath = 11, Sex = Sex.Male, Locale = Locale.Rural, AdultBodymass = 24.6m, HouseholdIncome = 120000},
                new DogProfile{AgeAtDeath = 14, Sex = Sex.Female, Locale = Locale.Rural, AdultBodymass = 28.1m, HouseholdIncome = 40000},
                new DogProfile{AgeAtDeath = 8, Sex = Sex.Female, Locale = Locale.Urban, AdultBodymass = 4.4m, HouseholdIncome = 24000},
                new DogProfile{AgeAtDeath = 6, Sex = Sex.Male, Locale = Locale.Urban, AdultBodymass = 45.7m, HouseholdIncome = 54000}
            };
        }
    }
}
