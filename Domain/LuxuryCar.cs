public class LuxuryCar : Car
{
    public LuxuryCar(
        string registrationNumber,
        string make,
        string model,
        int year,
        Money dailyRate,
        Engine engine
    )
        : base(registrationNumber, make, model, year, dailyRate, engine) { }

    public override Money CalculateRent(int days)
    {
        return CalculateRent(days, false);
    }

    public Money CalculateRent(int days, bool includeChauffeur)
    {
        decimal amount = DailyRate.Amount * days;

        if (includeChauffeur)
        {
            amount += 1000m * days;
        }

        return new Money { Amount = amount, Currency = DailyRate.Currency };
    }
}