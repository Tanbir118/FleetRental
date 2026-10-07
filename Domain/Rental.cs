public class Rental:IEntity
{
    public string Id { get; set; }
    public string VehicleRegistrationNumber { get; set; }
    public string CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public Money TotalCharge { get; set; }
}