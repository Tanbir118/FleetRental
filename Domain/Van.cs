public class Van : Vehicle
{
    private int _seatCount;

    public Van(
        string registrationNumber,
        string make,
        string model,
        int year,
        Money dailyRate,
        Engine engine,
        int seatcount
    )
        : base(registrationNumber, make, model, year, dailyRate, VehicleStatus.Available, engine)
    {
        SeatCount = seatcount;
    }

    public int SeatCount
    {
        get { return _seatCount; }
        set
        {
            if (value > 9 && value < 20)
            {
                _seatCount = value;
            }
            else
            {
                throw new ArgumentException("Seat count must be between 10 and 19.");
            }
        }
    }

    public override Money CalculateRent(int days)
    {
        if(days<2)
        {
            throw new ArgumentException("Days must be Greater 2 ");
        }

        decimal rent = (DailyRate.Amount * days) + (_seatCount * 50 * days);
        return new Money { Amount = rent, Currency = DailyRate.Currency };
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()} Seats: {SeatCount}";
    }
}
