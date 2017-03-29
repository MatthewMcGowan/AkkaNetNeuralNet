using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkkaNetNeuralNet.Core.Helpers;
using AkkaNetNeuralNet.Core.Model;

namespace AkkaNetNeuralNet.Core.Normalisation
{
    public static class HouseholdIncomeNormalisation
    {
        public static IEnumerable<DogProfile> NormaliseIncomes(this IEnumerable<DogProfile> profiles)
        {
            return profiles.Normalise(x => x.HouseholdIncome, DogProfileHelpers.UpdateHouseholdIncome);
        }
    }
}
