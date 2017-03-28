namespace AkkaNetNeuralNet.Core.Model
{
    public class DogProfile : IIndependentExpectancyVariable, IDependentExpectancyVariable
    {
        public decimal AgeAtDeath { get; set; }
        public Sex Sex { get; set; }
        public Locale Locale { get; set; }
        public decimal AdultBodymass { get; set; }
        public decimal HouseholdIncome { get; set; }
    }
}
