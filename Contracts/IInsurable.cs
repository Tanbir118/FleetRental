public interface IInsurable
{
    string PolicyNumber { get; }
    Money CalculatePremium();
}