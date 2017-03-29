using System.Collections.Generic;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNerualNet.Core.Test.TestData
{
    public static class DogProfileTestData
    {
        public static IEnumerable<DogProfile> GetTestDogProfiles()
        {
            return new List<DogProfile>
            {
                new DogProfile (2, Sex.Male, Breed.StBernard, 2, 2),
                new DogProfile (4, Sex.Male, Breed.Labrador, 4, 4),
                new DogProfile (10, Sex.Female, Breed.Bulldog, 10, 10),
            };
        }
    }
}
