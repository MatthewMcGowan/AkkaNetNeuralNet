using System.Collections.Generic;
using System.Linq;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AdultBodymassNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseMasses(this IEnumerable<DogProfile> profiles)
        {
            decimal min = profiles.Min(x => x.AdultBodymass);
            decimal max = profiles.Max(x => x.AdultBodymass);

            if (min == max) return EqualityCase(profiles);

            return profiles.Select(x => NormaliseMass(x, min, max));
        }

        static DogProfile NormaliseMass(DogProfile profile, decimal min, decimal max)
        {
            decimal mass = (profile.AdultBodymass - min) / (max - min);

            return new DogProfile(profile.AgeAtDeath, profile.Sex, profile.Breed, mass, profile.HouseholdIncome);
        }

        /// <summary>
        /// If min == max, we arbitrarily normalise to 0.5.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<DogProfile> EqualityCase(IEnumerable<DogProfile> profiles)
        {
            DogProfile NormaliseToAvg(DogProfile p) => new DogProfile(p.AgeAtDeath, p.Sex, p.Breed, 0.5m, p.HouseholdIncome);

            return profiles.Select(x => NormaliseToAvg(x));
        }
    }
}
