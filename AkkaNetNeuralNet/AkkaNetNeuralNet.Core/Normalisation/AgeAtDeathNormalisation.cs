using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class AgeAtDeathNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseAges(this IEnumerable<DogProfile> profiles)
        {
            // AgeAtDeath is our y-value
            decimal min = profiles.Min(x => x.AgeAtDeath);
            decimal max = profiles.Max(x => x.AgeAtDeath);

            return profiles.Select(x => NormaliseAge(x, min, max));
        }

        static DogProfile NormaliseAge(DogProfile profile, decimal min, decimal max)
        {
            profile.AgeAtDeath = (profile.AgeAtDeath - min) / (max - min);
            return profile;
        }
    }
}
