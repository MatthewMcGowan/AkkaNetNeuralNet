using System.Collections.Generic;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class Normalisation
    {
        public static IEnumerable<DogProfile> Normalise(this IEnumerable<DogProfile> profiles)
        {
            return profiles
                .NormaliseAges()
                .NormaliseMasses()
                .NormaliseIncomes();

            //TODO: Effects encoding currently encapsulated in type. Inconsistant.
        }
    }
}
