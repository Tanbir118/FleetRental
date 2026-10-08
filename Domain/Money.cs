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
}
