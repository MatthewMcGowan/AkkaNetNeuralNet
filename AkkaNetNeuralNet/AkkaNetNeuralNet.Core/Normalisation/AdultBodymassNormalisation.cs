using System.Collections.Generic;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AdultBodymassNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseMasses(this IEnumerable<DogProfile> profiles)
        {
            return DogProfileDecimalNormalisation.Normalise(profiles, x => x.AdultBodymass, DogProfileHelpers.UpdateAdultBodyMass);
        }
    }
}
