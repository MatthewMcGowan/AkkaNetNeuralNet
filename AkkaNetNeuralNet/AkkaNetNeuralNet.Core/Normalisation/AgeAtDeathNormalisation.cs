using System.Collections.Generic;
using System.Linq;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AgeAtDeathNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseAges(this IEnumerable<DogProfile> profiles)
        {
            decimal min = profiles.Min(x => x.AgeAtDeath);
            decimal max = profiles.Max(x => x.AgeAtDeath);

            if (min == max) return EqualityCase(profiles);

            return profiles.Select(x => NormaliseAge(x, min, max));
        }

        static DogProfile NormaliseAge(DogProfile profile, decimal min, decimal max)
        {
            decimal age = (profile.AgeAtDeath - min) / (max - min);

            return new DogProfile(age, profile.Sex, profile.Breed, profile.AdultBodymass, profile.HouseholdIncome);
        }

        /// <summary>
        /// If min == max, we arbitrarily normalise to 0.5.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<DogProfile> EqualityCase(IEnumerable<DogProfile> profiles)
        {
            DogProfile NormaliseToAvg(DogProfile p) => new DogProfile(0.5m, p.Sex, p.Breed, p.AdultBodymass, p.HouseholdIncome);

            return profiles.Select(x => NormaliseToAvg(x));
        }
    }
}
