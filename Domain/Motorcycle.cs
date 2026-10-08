public class Motorcycle : Vehicle, IRentable, IMaintainable
{
    private DateTime _startDate;
    private DateTime? _lastServiceDate;

    public Motorcycle(
        string registrationNumber,
        string make,
        string model,
        int year,
        Money dailyRate,
        Engine engine,
        DateTime startDate
    )
        : base(registrationNumber, make, model, year, dailyRate, VehicleStatus.Available, engine)
    {
        _startDate = startDate;
    }

    public override Money CalculateRent(int days)
    {
        decimal amount = 0;
        var count = 0;
        DateTime? freeday = null;
        for (int i = 0; i < days; i++)
        {
            DateTime currentDate = _startDate.AddDays(i);

            // if ((i + 1) % 7 == 0)
            // {
            //     continue;
            // }

            // decimal dailyAmount = DailyRate.Amount;

            // if (IsWeekend(currentDate))
            // {
            //     dailyAmount = dailyAmount * 1.25m;
            // }

            // amount = amount + dailyAmount;

            if ((i + 1) % 7 == 0)
            {
                if (IsWeekend(currentDate))
                {
                    //rent lagbe..
                    //next weekdya find....
                    //make taht free...
                    // freeday = currentDate.AddDays(-1);
                    DateTime nextweekday = currentDate.AddDays(1);
                    while (IsWeekend(nextweekday))
                    {
                        nextweekday = nextweekday.AddDays(1);
                    }

                    freeday = nextweekday;
                }
                else
                {
                    //rent lagbe naa its free
                    continue;
                }
            }
            if (freeday.HasValue && currentDate.Date == freeday.Value.Date)
            {
                continue;
            }

            decimal dailyAmount = DailyRate.Amount;

            if (IsWeekend(currentDate))
            {
                dailyAmount = dailyAmount * 1.25m;
            }

            amount = amount + dailyAmount;
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
}
