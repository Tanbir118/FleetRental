public class RentalService
{
    public void Rent(string registrationNumber, string customerId, int days)
    {
        Vehicle vehicle = new Car(registrationNumber, "Honda", "City");

        Customer customer = new Customer { Id = customerId, Name = "Test Customer" };

        Rent(vehicle, customer, days);
    }

    public void Rent(Vehicle vehicle, Customer customer, int days)
    {
        DateTime from = DateTime.Now;
        DateTime to = from.AddDays(days);

        Rent(vehicle, customer, from, to);
    }

    public void Rent(Vehicle vehicle, Customer customer, DateTime from, DateTime to)
    {
        Rental rental = new Rental
        {
            Id = "R001",
            VehicleRegistrationNumber = vehicle.RegistrationNumber,
            CustomerId = customer.Id,
            StartDate = from,
            ExpectedReturnDate = to,
            TotalCharge = vehicle.CalculateRent((to - from).Days),
        };
    }
}
