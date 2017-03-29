using System.Collections.Generic;
using System.Linq;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AdultBodymassNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseMasses(this IEnumerable<DogProfile> profiles)
        {
            var normaliser = new DogProfileDecimalNormalisation(x => x.AdultBodymass, DogProfileHelpers.UpdateAdultBodyMass);

            return normaliser.Normalise(profiles);
        }
    }
}
