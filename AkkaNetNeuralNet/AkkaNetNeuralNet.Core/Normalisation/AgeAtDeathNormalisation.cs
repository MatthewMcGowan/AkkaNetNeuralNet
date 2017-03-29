using System.Collections.Generic;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AgeAtDeathNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseAges(this IEnumerable<DogProfile> profiles)
        {
            return DogProfileDecimalNormalisation.Normalise(profiles, x => x.AgeAtDeath,
                DogProfileHelpers.UpdateAgeAtDeath);
        }
    }
}
