namespace AkkaNetNeuralNet.Core.Model
{
    public interface IIndependentVariable
    {
        Sex Sex { get; }
        Breed Breed { get; }
        decimal AdultBodymass { get; } //Kg
        decimal HouseholdIncome { get; } //£
    }
}