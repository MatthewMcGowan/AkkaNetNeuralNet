namespace AkkaNetNeuralNet.Core.Model
{
    public class DogProfile : IDogProfile
    {
        public DogProfile(decimal ageAtDeath, Sex sex, Locale locale, decimal adultBodymass, decimal householdIncome)
        {
            AgeAtDeath = ageAtDeath;
            Sex = sex;
            Locale = locale;
            AdultBodymass = adultBodymass;
            HouseholdIncome = householdIncome;
        }

        public decimal AgeAtDeath { get; }
        public Sex Sex { get; }
        public Locale Locale { get; }
        public decimal AdultBodymass { get; }
        public decimal HouseholdIncome { get; }
    }
}
