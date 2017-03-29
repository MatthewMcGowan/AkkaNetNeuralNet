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
                new DogProfile(7, Sex.Male, Breed.StBernard, 120.2m, 64000),
                new DogProfile(11, Sex.Male, Breed.Labrador, 24.6m, 120000),
                new DogProfile(14, Sex.Female, Breed.Labrador, 28.1m, 40000),
                new DogProfile(8, Sex.Female, Breed.Bulldog, 4.4m, 24000),
                new DogProfile(6, Sex.Male, Breed.Bulldog, 8.7m, 54000)
            };
        }
    }
}
