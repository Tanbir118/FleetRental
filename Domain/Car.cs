public class Car : Vehicle, IRentable, IMaintainable, IInsurable
{
    private DateTime? _lastServiceDate;

    public Car(
        string registrationNumber,
        string make,
        string model,
        int year,
        Money dailyRate,
        Engine engine
    )
        : base(registrationNumber, make, model, year, dailyRate, VehicleStatus.Available, engine)
    { }

    public Car(string registrationNumber, string make, string model)
        : this(
            registrationNumber,
            make,
            model,
            2024,
            new Money { Amount = 2000, Currency = "INR" },
            new Engine()
        ) { }

    public override Money CalculateRent(int days)
    {
        decimal amount = DailyRate.Amount * days;

        if (days >= 7)
        {
            amount = amount * 0.90m;
        }

        return new Money { Amount = amount, Currency = DailyRate.Currency };
    }

    public new string GetDescription()
    {
        return "This is a Car";
    }

    public bool IsAvailable
    {
        get { return Status == VehicleStatus.Available; }
    }

    public void MarkRented()
    {
        Status = VehicleStatus.Rented;
    }

    public void MarkReturned()
    {
        Status = VehicleStatus.Available;
    }

    public DateTime? LastServiceDate
    {
        get { return _lastServiceDate; }
    }

    public void ScheduleService(DateTime date)
    {
        _lastServiceDate = date;
    }

    public bool IsServiceDue()
    {
        if (!_lastServiceDate.HasValue)
            return true;

        return DateTime.Now >= _lastServiceDate.Value;
    }

    public string PolicyNumber
    {
        get {return "asd-csc-cs";}
    }

   public Money CalculatePremium()
{
    decimal premium = DailyRate.Amount * 0.05m;

    return new Money
    {
        Amount = premium,
        Currency = DailyRate.Currency
    };
}

}
