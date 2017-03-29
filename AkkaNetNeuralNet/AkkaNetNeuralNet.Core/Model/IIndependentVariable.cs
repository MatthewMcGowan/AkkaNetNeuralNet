namespace AkkaNetNeuralNet.Core.Model
{
    public interface IIndependentVariable
    {
        Sex Sex { get; }
        Locale Locale { get; }
        decimal AdultBodymass { get; } //Kg
        decimal HouseholdIncome { get; } //�
    }
}