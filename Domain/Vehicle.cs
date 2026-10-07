public enum VehicleStatus
{
    Available,
    Rented,
    UnderService,
}

public abstract class Vehicle : IReportable,IEntity
{
    private string _registrationNumber;
    private string _make;
    private string _model;
    private int _year;
    private Money _dailyRate;
    private VehicleStatus _status;

    public string Id
    {
        get { return RegistrationNumber; }
    }
   public string RegistrationNumber
{
    get { return _registrationNumber; }
   private set
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Registration number cannot be empty.");

        _registrationNumber = value;
    }
}
    public string Make
    {
        get { return _make; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Make cannot be empty.");
            }

            _make = value;
        }
    }
    public string Model
    {
        get { return _model; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be empty.");
            }

            _model = value;
        }
    }
    public int Year
    {
        get { return _year; }
        set
        {
            if (value < 1980 || value > DateTime.Now.Year)
            {
                throw new ArgumentException("Year must be between 1980 and current year.");
            }

            _year = value;
        }
    }
    public Money DailyRate
    {
        get { return _dailyRate; }
        set
        {
            if (value.Amount <= 0)
            {
                throw new ArgumentException("Daily rate must be a positive amount.");
            }

            _dailyRate = value;
        }
    }
    public VehicleStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }
    public Engine Engine { get; set; }

    public Vehicle(
        string registrationNumber,
        string make,
        string model,
        int year,
        Money dailyRate,
        VehicleStatus status,
        Engine engine
    )
    {
        RegistrationNumber = registrationNumber;
        Make = make;
        Model = model;
        Year = year;
        DailyRate = dailyRate;
        Status = status;
        Engine = engine;
    }

    public abstract Money CalculateRent(int days);

    protected bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    public virtual string GetDescription() => $"{Year} {Make} {Model} {RegistrationNumber}";
}
