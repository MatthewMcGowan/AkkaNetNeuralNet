using AkkaNetNeuralNet.Core.Model;

using C = System.Console;

namespace AkkaNetNeuralNet.Console
{
    public static class ConsoleHelper
    {
        private const string DecimalFormat = "0.###";

        public static void PrintDogProfileHeader()
        {
            C.WriteLine("Age\tSex\tMass\tIncome\tBreed");
        }

        public static void Print(DogProfile profile)
        {
            var fields = new string[]
            {
                profile.AgeAtDeath.ToString(DecimalFormat),
                profile.Sex.ToString(),
                profile.AdultBodymass.ToString(DecimalFormat),
                profile.HouseholdIncome.ToString(DecimalFormat),
                profile.Breed.Name
            };

            C.WriteLine(string.Join("\t", fields));
        }
    }
}
