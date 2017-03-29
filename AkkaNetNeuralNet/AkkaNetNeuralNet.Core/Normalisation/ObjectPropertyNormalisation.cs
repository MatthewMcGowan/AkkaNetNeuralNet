using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class ObjectPropertyNormalisation
    {
        public static IEnumerable<T> NormaliseProperty<T>(this IEnumerable<T> profiles, 
            Func<T, decimal> propertyAccessorFunc,
            Func<T, decimal, T> propertyUpdateInFunc)
        {
            decimal min = profiles.Min(propertyAccessorFunc);
            decimal max = profiles.Max(propertyAccessorFunc);

            if (min == max) return profiles.Select(x => propertyUpdateInFunc(x, 0.5m));

            return profiles.Select(x => MinMaxNormalise(x));

            T MinMaxNormalise(T profile)
            {
                decimal mass = (propertyAccessorFunc(profile) - min) / (max - min);
                return propertyUpdateInFunc(profile, mass);
            }
        }
    }
}
