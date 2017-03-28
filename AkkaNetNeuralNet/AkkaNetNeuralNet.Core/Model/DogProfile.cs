using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaNetNeuralNet.Core.Model
{
    public class DogProfile : IIndependentExpectancyVariable, IDependentExpectancyVariable
    {
        public DogProfile(int ageAtDeath, Sex sex, Locale locale, decimal adultBodymass, decimal householdIncome)
        {
            AgeAtDeath = ageAtDeath;
            Sex = sex;
            Locale = locale;
            AdultBodymass = adultBodymass;
            HouseholdIncome = householdIncome;
        }

        public int AgeAtDeath { get; }
        public Sex Sex { get; }
        public Locale Locale { get; }
        public decimal AdultBodymass { get; }
        public decimal HouseholdIncome { get; }
    }
}
