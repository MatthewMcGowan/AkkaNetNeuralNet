using System;
using System.Collections.Generic;
using System.Linq;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class DogProfileDecimalNormalisation
    {
        public static IEnumerable<DogProfile> Normalise(IEnumerable<DogProfile> profiles, 
            Func<DogProfile, decimal> propertyAccessorFunc,
            Func<DogProfile, decimal, DogProfile> propertyUpdateInFunc)
        {
            decimal min = profiles.Min(propertyAccessorFunc);
            decimal max = profiles.Max(propertyAccessorFunc);

            if (min == max) return profiles.Select(x => propertyUpdateInFunc(x, 0.5m));

            return profiles.Select(x => MinMaxNormalise(x));

            DogProfile MinMaxNormalise(DogProfile profile)
            {
                decimal mass = (propertyAccessorFunc(profile) - min) / (max - min);
                return propertyUpdateInFunc(profile, mass);
            }
        }
    }
}
