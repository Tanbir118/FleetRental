public struct Money
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Cannot add money with different currencies.");
        }

        return new Money { Amount = a.Amount + b.Amount, Currency = a.Currency };
    }

    public static Money operator -(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Cannot subtract money with different currencies.");
        }

        return new Money { Amount = a.Amount - b.Amount, Currency = a.Currency };
    }

    public static bool operator ==(Money a, Money b)
    {
        return a.Amount == b.Amount && a.Currency == b.Currency;
    }

    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }
    public override bool Equals(object? obj)
    {
        if (obj is Money other)
        {
            return this == other;
        }

        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }

    public static bool operator >(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Cannot compare money with different currencies.");
        }

        return a.Amount > b.Amount;
    }

    public static bool operator <(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Cannot compare money with different currencies.");
        }

        return a.Amount < b.Amount;
    }

    public Money[] Split(int parts)
    {
        if (parts <= 0)
        {
            throw new ArgumentException("Parts must be greater than zero.");
        }

        decimal perPart = Math.Floor(Amount / parts * 100) / 100;
        decimal remainder = Amount - (perPart * parts);
        int extraCount = (int)(remainder * 100);
        
        Money[] result = new Money[parts];
        for (int i = 0; i < parts; i++)
        {
            decimal amt = perPart;
            if (i < extraCount)
            {
                amt += 0.01m;
            }
            result[i] = new Money { Amount = amt, Currency = Currency };
        }

        return result;
    }
}
