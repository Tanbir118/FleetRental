public class Customer : IReportable,IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
    public string LicenceNumber { get; set; }
    public bool IsBlacklisted { get; set; }
}

