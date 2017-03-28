using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class Normalisation
    {
        public static IEnumerable<DogProfile> Normalise(this IEnumerable<DogProfile> profiles)
        {
            return profiles
                .NormaliseAges();
        }
    }
}
