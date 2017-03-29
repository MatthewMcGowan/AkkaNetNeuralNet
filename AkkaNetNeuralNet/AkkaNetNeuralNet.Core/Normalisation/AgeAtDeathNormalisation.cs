using System.Collections.Generic;
using System.Linq;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AgeAtDeathNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseAges(this IEnumerable<DogProfile> profiles)
        {
            var normaliser = new DogProfileDecimalNormalisation(x => x.AgeAtDeath, DogProfileHelpers.UpdateAgeAtDeath);

            return normaliser.Normalise(profiles);
        }
    }
}
