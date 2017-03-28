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

    public interface IDependentExpectancyVariable
    {
        int AgeAtDeath { get; }
    }

    public interface IIndependentExpectancyVariable
    {
        Sex Sex { get; }
        Locale Locale { get; }
        decimal AdultBodymass { get; } //Kg
        decimal HouseholdIncome { get; } //£
    }

    public enum Sex
    {
        Male = -1,
        Female = 1
    }

    public class Locale
    {
        public LocaleName Name { get; private set; }
        public (decimal, decimal) Encoding { get; private set; }

        private Locale() { }

        private Locale(LocaleName name, (decimal, decimal) encoding)
        {
            Name = name;
            Encoding = encoding;
        }

        public static Locale Rural = new Locale(LocaleName.Rural, (1m, 0m));
        public static Locale Suburban = new Locale(LocaleName.Suburban, (0m, 1m));
        public static Locale Urban = new Locale(LocaleName.Urban, (-1m, 1m));

        public enum LocaleName
        {
            Rural,
            Suburban,
            Urban
        }
    }
}
