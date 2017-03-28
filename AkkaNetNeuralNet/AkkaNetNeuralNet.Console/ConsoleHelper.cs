using AkkaNetNeuralNet.Core.Model;

using C = System.Console;

namespace AkkaNetNeuralNet.Console
{
    public static class ConsoleHelper
    {
        public static void PrintDogProfileHeader()
        {
            C.WriteLine("Age\tSex\tMass\tIncome\tLocale");
        }

        public static void Print(DogProfile profile)
        {
            var fields = new string[]
            {
                profile.AgeAtDeath.ToString(),
                profile.Sex.ToString(),
                profile.AdultBodymass.ToString(),
                profile.HouseholdIncome.ToString(),
                profile.Locale.Name.ToString()
            };

            C.WriteLine(string.Join("\t", fields));
        }
    }
}
