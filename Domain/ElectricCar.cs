public sealed class ElectricCar : Car
{
    public ElectricCar(
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
        Money rent = base.CalculateRent(days);

        decimal amount = rent.Amount * 0.85m;

        amount = amount + 500;

        return new Money { Amount = amount, Currency = rent.Currency };
    }
}
