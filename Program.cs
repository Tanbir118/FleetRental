// // Payment.Pay(amount);
// //......................................................................................................................................

// Money a = new Money { Amount = 1000, Currency = "INR" };
// Money b = new Money { Amount = 300, Currency = "INR" };

// Money c = a + b; // 1300 INR
// Money d = a - b; // 700 INR

// Console.WriteLine(c + "&" + d);

// var engine = new Engine();
// engine.FuelType = FuelType.Petrol;
// engine.cc = 2000;
// engine.HorsePower = 150;

// Console.WriteLine(
//     $"Engine Details: Fuel Type: {engine.FuelType}, CC: {engine.cc}, Horse Power: {engine.HorsePower}"
// );

// Console.WriteLine("................................................................\n");
// var car = new Car(
//     "WB01",
//     "Honda",
//     "City",
//     2024,
//     new Money { Amount = 2000, Currency = "INR" },
//     engine
// );

// var electricCar = new ElectricCar(
//     "WB02",
//     "Tata",
//     "Nexon EV",
//     2024,
//     new Money { Amount = 2500, Currency = "INR" },
//     engine
// );

// var motorcycle = new Motorcycle(
//     "WB03",
//     "Royal Enfield",
//     "Classic 350",
//     2023,
//     new Money { Amount = 1000, Currency = "INR" },
//     engine,
//     new DateTime(2026, 9, 18)
// );

// var truck = new Truck(
//     "WB04",
//     "Tata",
//     "Prima",
//     2022,
//     new Money { Amount = 3000, Currency = "INR" },
//     engine,
//     10
// );

// List<Vehicle> vehicles = new List<Vehicle>();

// vehicles.Add(car);
// vehicles.Add(electricCar);
// vehicles.Add(motorcycle);
// vehicles.Add(truck);

// foreach (Vehicle vehicle in vehicles)
// {
//     Money rent = vehicle.CalculateRent(7);

//     Console.WriteLine("\n" + $"{vehicle.GetDescription()} = {rent}");
// }

// // var car1 = new Car("WB01",
// //     "Honda",
// //     "City",
// //     2024,
// //     new Money { Amount = 2000, Currency = "INR" },
// //     engine);

// //     Console.WriteLine(car1.GetDescription());

// //     Vehicle vehicle1 = car1; // Output: This is a Car

// //      Console.WriteLine(vehicle1.GetDescription());

// Console.WriteLine("'''''''''''''''''''''''''''''\n");

// Repository<Customer> customerRepository = new Repository<Customer>();

// Customer customer = new Customer
// {
//     Id = "C001",
//     Name = "Ron"
// };

// customerRepository.Add(customer);

// Customer result = customerRepository.GetById("C001");

// Console.WriteLine(result.Name);

// Repository<Rental>carrepo = new Repository<Rental>();

// Rental rental = new Rental
// { 
//     Id="12341",
//     VehicleRegistrationNumber="wb53g1589",
// };

// carrepo.Add(rental);

// var res = carrepo.GetAll();


// // Repository<Car>CarRepo = new Repository<Car>();

// // Car car1 = new Car(

// //     "asd",
// //     "aad",
// //     "casd"
// // );

// // CarRepo.Add(car1);


// foreach (var rentalItem in res)
// {
//     Console.WriteLine(rentalItem.Id);
//     Console.WriteLine(rentalItem.VehicleRegistrationNumber);
// }

// var van = new Van(
//     "WB04",
//     "Tata",
//     "Prima",
//     2022,
//     new Money { Amount = 3000, Currency = "INR" },
//     new Engine { FuelType = FuelType.Disel, cc = 5000, HorsePower = 200 },  // Engine object
//     11  // seatCount
// );

// Console.WriteLine(van.SeatCount);

// Console.WriteLine(van.CalculateRent(2));
// Console.WriteLine(van.GetDescription());

var luxurycar = new LuxuryCar(
    "WB04",
    "Tata",
    "Prima",
    2022,
    new Money { Amount = 8000, Currency = "INR" },
    new Engine { FuelType = FuelType.Disel, cc = 5000, HorsePower = 200 }
);

Console.WriteLine(luxurycar.CalculateRent(11));
Console.WriteLine(luxurycar.CalculateRent(11,true));

Console.WriteLine("................................................................\n");

var engine = new Engine();

var car = new Car(
    "WB01",
    "Honda",
    "City",
    2024,
    new Money { Amount = 2000, Currency = "INR" },
    engine
);

var electricCar = new ElectricCar(
    "WB02",
    "Tata",
    "Nexon EV",
    2024,
    new Money { Amount = 2500, Currency = "INR" },
    engine
);

var motorcycle = new Motorcycle(
    "WB03",
    "Royal Enfield",
    "Classic 350",
    2023,
    new Money { Amount = 1000, Currency = "INR" },
    engine,
    new DateTime(2026, 9, 18)
);

var truck = new Truck(
    "WB04",
    "Tata",
    "Prima",
    2022,
    new Money { Amount = 3000, Currency = "INR" },
    engine,
    10
);

var van = new Van(
    "WB04",
    "van",
    "toto",
    2022,
    new Money { Amount = 3000, Currency = "INR" },
    new Engine { FuelType = FuelType.Disel, cc = 5000, HorsePower = 200 },  // Engine object
    11 
);


List<Vehicle> vehicles = new List<Vehicle>();

vehicles.Add(car);
vehicles.Add(electricCar);
vehicles.Add(motorcycle);
vehicles.Add(truck);
vehicles.Add(van);
vehicles.Add(luxurycar);

foreach (Vehicle vehicle in vehicles)
{
    Money rent = vehicle.CalculateRent(7);

    Console.WriteLine("\n" + $"{vehicle.GetDescription()} = {rent}");
}
Console.WriteLine("\noverloaded rent for luxury car"+luxurycar.CalculateRent(7, true)+"\n");


Console.WriteLine("\n===== Money Operators & Split Test =====\n");

Money m1 = new Money { Amount = 5000, Currency = "INR" };
Money m2 = new Money { Amount = 3000, Currency = "INR" };

Console.WriteLine($"m1 = {m1}");
Console.WriteLine($"m2 = {m2}");
Console.WriteLine($"m1 > m2 = {m1 > m2}");
Console.WriteLine($"m1 < m2 = {m1 < m2}");

Console.WriteLine($"\nSplit Rs 100 into 3 parts:");
Money hundred = new Money { Amount = 100, Currency = "INR" };
Money[] parts = hundred.Split(3);
decimal total = 0;
foreach (Money part in parts)
{
    Console.WriteLine($"  {part}");
    total += part.Amount;
}
Console.WriteLine($"  Total = {total} (must equal {hundred.Amount})");

