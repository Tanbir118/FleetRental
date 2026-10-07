public enum FuelType
{
    Petrol,
    Disel,
    Electric,
}

public class Engine
{
    public FuelType FuelType { get; set; }
    public int cc { get; set; }
    public int HorsePower { get; set; }
}
