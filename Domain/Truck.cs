public class Truck : Vehicle, IRentable, IMaintainable, IInsurable
{
    private DateTime? _lastServiceDate;
    public int CapacityInTonnes { get; set; }

    public Truck(
        string registrationNumber,
        string make,
        string model,
        int year,
        Money dailyRate,
        Engine engine,
        int capacityInTonnes
    )
        : base(registrationNumber, make, model, year, dailyRate, VehicleStatus.Available, engine)
    {
        CapacityInTonnes = capacityInTonnes;
    }

    public override Money CalculateRent(int days)
    {
        decimal amount = DailyRate.Amount * days;

        decimal perTonnCost;

        if (CapacityInTonnes <= 10)
        {
            perTonnCost = CapacityInTonnes * 300;
        }
        else
        {
            perTonnCost = (10 * 300) + ((CapacityInTonnes - 10) * 500);
        }

        amount = amount + perTonnCost;

        if (days < 10)
        {
            amount = amount + 1000;
        }

        return new Money { Amount = amount, Currency = DailyRate.Currency };
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

    void IMaintainable.ScheduleService(DateTime date)
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
        get { return "asd-csc-cs"; }
    }

    public Money CalculatePremium()
    {
        decimal premium = DailyRate.Amount * 0.05m;

        return new Money { Amount = premium, Currency = DailyRate.Currency };
    }
}
