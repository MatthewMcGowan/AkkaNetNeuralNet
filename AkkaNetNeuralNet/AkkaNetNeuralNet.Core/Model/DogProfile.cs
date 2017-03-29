namespace AkkaNetNeuralNet.Core.Model
{
    public class DogProfile : IDogProfile
    {
        public DogProfile(decimal ageAtDeath, Sex sex, Breed breed, decimal adultBodymass, decimal householdIncome)
        {
            AgeAtDeath = ageAtDeath;
            Sex = sex;
            Breed = breed;
            AdultBodymass = adultBodymass;
            HouseholdIncome = householdIncome;
        }

        public decimal AgeAtDeath { get; }
        public Sex Sex { get; }
        public Breed Breed { get; }
        public decimal AdultBodymass { get; }
        public decimal HouseholdIncome { get; }
    }
}
