using System;
using System.Collections.Generic;
using System.Linq;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public class DogProfileDecimalNormalisation
    {
        private readonly Func<DogProfile, decimal> _propertyAccessorFunc;
        private readonly Func<DogProfile, decimal, DogProfile> _propertyUpdateInFunc;

        public DogProfileDecimalNormalisation(Func<DogProfile, decimal> propertyAccessorFunc,
            Func<DogProfile, decimal, DogProfile> propertyUpdateInFunc)
        {
            _propertyAccessorFunc = propertyAccessorFunc;
            _propertyUpdateInFunc = propertyUpdateInFunc;
        }

        public IEnumerable<DogProfile> Normalise(IEnumerable<DogProfile> profiles)
        {
            decimal min = profiles.Min(_propertyAccessorFunc);
            decimal max = profiles.Max(_propertyAccessorFunc);

            if (min == max) return Equalise(profiles);

            return profiles.Select(x => MinMaxNormalise(x, min, max));
        }

        private DogProfile MinMaxNormalise(DogProfile profile, decimal min, decimal max)
        {
            decimal mass = (_propertyAccessorFunc(profile) - min) / (max - min);

            return _propertyUpdateInFunc(profile, mass);
        }

        /// <summary>
        /// If min == max, we arbitrarily normalise to 0.5.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<DogProfile> Equalise(IEnumerable<DogProfile> profiles)
        {
            return profiles.Select(x => _propertyUpdateInFunc(x, 0.5m));
        }
    }
}
