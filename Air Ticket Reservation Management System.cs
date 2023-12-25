using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Flight
{
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public double TicketPrice { get; set; }
    public double FareDiscount { get; set; }
    public int TotalTicketQuantity { get; set; }
    public int RemainingTicketQuantity { get; set; }

    public Flight(string flightNumber, string departureCity, string arrivalCity, DateTime departureTime, DateTime arrivalTime, double ticketPrice, double fareDiscount, int totalTicketQuantity)
    {
        FlightNumber = flightNumber;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        TicketPrice = ticketPrice;
        FareDiscount = fareDiscount;
        TotalTicketQuantity = totalTicketQuantity;
        RemainingTicketQuantity = totalTicketQuantity;
    }

}

class Customer
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string IDCard { get; set; }
    public string Name { get; set; }
    public Customer(string username, string password, string idCard, string name)
    {
        Username = username;
        Password = password;
        IDCard = idCard;
        Name = name;
    }
}
class Program
{
    static List<Flight> flights = new List<Flight>();
    static List<Customer> customers = new List<Customer>();
    private static string departureCity;
    private static string arrivalCity;
    private static DateTime departureTime;
    private static DateTime arrivalTime;
    private static double ticketPrice;
    private static double fareDiscount;
    private static int totalTicketQuantity;
    private static string password;
    private static string idCard;
    private static string name;

    static void Main()
    {
        LoadData(); // Load flight and customer data from files

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("                                                     AIR TICKET RESERVATION INFORMATION SYSTEM           ");
            Console.WriteLine("                                                  ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Save Data and Exit");
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AdministratorMenu();
                    break;
                case 2:
                    CustomerMenu();
                    break;
                case 3:
                    SaveData(); // Save flight and customer data to files
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Your Choice is Invalid. Please Try again!");
                    break;
            }
        }
    }

    static void AdministratorMenu()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("                                                                    Administrator           ");
        Console.WriteLine("                                                               ----------------------");
        Console.WriteLine();
        Console.WriteLine("1. Enter Flight Information");
        Console.WriteLine("2. Modify Flight Information");
        Console.WriteLine("3. Delete Flight");
        Console.WriteLine("4. Query Flight Information");
        Console.WriteLine("5. Sort Flights by Number");
        Console.WriteLine("6. Back to Main Menu");
        Console.WriteLine();
        Console.Write("Enter Your Choice: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                EnterFlightInformation();
                break;
            case 2:
                ModifyFlightInformation();
                break;
            case 3:
                DeleteFlight();
                break;
            case 4:
                QueryFlightInformation();
                break;
            case 5:
                SortFlights();
                break;
            case 6:
                return;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
}

static void EnterFlightInformation()
{
    Console.WriteLine();
    Console.Write("Flight Number: ");
    string flightNumber = Console.ReadLine();
    
    Console.Write("Departure City: ");
    string departureCity = Console.ReadLine();
    
    Console.Write("Arrival City: ");
    string arrivalCity = Console.ReadLine();
    
    Console.Write("Departure Time (yyyy-MM-dd HH:mm): ");
    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime departureTime))
    {
        Console.Write("Arrival Time (yyyy-MM-dd HH:mm): ");
        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime arrivalTime))
        {
            Console.Write("Ticket Price: ");
            double ticketPrice;
            if (double.TryParse(Console.ReadLine(), out ticketPrice))
            {
                Console.Write("Fare Discount: ");
                double fareDiscount;
                if (double.TryParse(Console.ReadLine(), out fareDiscount))
                {
                    Console.Write("Total Ticket Quantity: ");
                    int totalTicketQuantity;
                    if (int.TryParse(Console.ReadLine(), out totalTicketQuantity))
                    {
                        Flight newFlight = new Flight(flightNumber, departureCity, arrivalCity, departureTime, arrivalTime, ticketPrice, fareDiscount, totalTicketQuantity);
                        flights.Add(newFlight);

                        Console.WriteLine("Flight information entered successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Total Ticket Quantity. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for Fare Discount. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Ticket Price. Please enter a valid number.");
            }
        }

        else
        {
            Console.WriteLine("Invalid input for Arrival Time. Please enter a valid date and time in the format yyyy-MM-dd HH:mm.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input for Departure Time. Please enter a valid date and time in the format yyyy-MM-dd HH:mm.");
    }
}


static void ModifyFlightInformation()
{
    Console.Write("Enter The Flight Number to Modify: ");
    string flightNumber = Console.ReadLine();
    Flight flightToModify = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

    if (flightToModify != null)
    {
        Console.WriteLine();
        Console.WriteLine("Current Flight Information:");
        Console.WriteLine($"Flight Number: {flightToModify.FlightNumber}");
        Console.WriteLine($"Departure City: {flightToModify.DepartureCity}");
        Console.WriteLine($"Arrival City: {flightToModify.ArrivalCity}");
        Console.WriteLine($"Departure Time: {flightToModify.DepartureTime}");
        Console.WriteLine($"Arrival Time: {flightToModify.ArrivalTime}");
        Console.WriteLine($"Ticket Price: {flightToModify.TicketPrice}");
        Console.WriteLine($"Fare Discount: {flightToModify.FareDiscount}");
        Console.WriteLine($"Total Ticket Quantity: {flightToModify.TotalTicketQuantity}");
        Console.WriteLine($"Remaining Ticket Quantity: {flightToModify.RemainingTicketQuantity}");

        Console.WriteLine("Enter new flight information (or press Enter to keep existing value):");

        Console.Write("Departure City: ");
        string newDepartureCity = Console.ReadLine();
        if (!string.IsNullOrEmpty(newDepartureCity))
        {
            flightToModify.DepartureCity = newDepartureCity;
        }

        Console.Write("Arrival City: ");
        string newArrivalCity = Console.ReadLine();
        if (!string.IsNullOrEmpty(newArrivalCity))
        {
            flightToModify.ArrivalCity = newArrivalCity;
        }

        Console.Write("Departure Time (yyyy-MM-dd HH:mm): ");
        string newDepartureTimeInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(newDepartureTimeInput))
        {
            if (DateTime.TryParseExact(newDepartureTimeInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime newDepartureTime))
            {
                flightToModify.DepartureTime = newDepartureTime;
            }
            else
            {
                Console.WriteLine("Invalid input for Departure Time. The existing value will be kept.");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Flight Information Modified Successfully.");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Flight not found.");
    }
}


static void DeleteFlight()
{
    Console.WriteLine();
    Console.Write("Enter Flight Number to Delete: ");
    string flightNumber = Console.ReadLine();
    Flight flightToDelete = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

    if (flightToDelete != null)
    {
        if (flightToDelete.RemainingTicketQuantity == flightToDelete.TotalTicketQuantity)
        {
            flights.Remove(flightToDelete);
            Console.WriteLine();
            Console.WriteLine("Flight Deleted Successfully.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Cannot Delete Flight With Booked Tickets.");
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Flight not found.");
    }
}

static void QueryFlightInformation()
{
    Console.WriteLine();
    Console.Write("Enter Flight Number: ");
    string flightNumber = Console.ReadLine();
    Flight queriedFlight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

    if (queriedFlight != null)
    {
        Console.WriteLine();
        Console.WriteLine("Flight Information:");
        Console.WriteLine($"Flight Number: {queriedFlight.FlightNumber}");
        Console.WriteLine($"Departure City: {queriedFlight.DepartureCity}");
        Console.WriteLine($"Arrival City: {queriedFlight.ArrivalCity}");
        Console.WriteLine($"Departure Time: {queriedFlight.DepartureTime}");
        Console.WriteLine($"Arrival Time: {queriedFlight.ArrivalTime}");
        Console.WriteLine($"Ticket Price: {queriedFlight.TicketPrice}");
        Console.WriteLine($"Fare Discount: {queriedFlight.FareDiscount}");
        Console.WriteLine($"Total Ticket Quantity: {queriedFlight.TotalTicketQuantity}");
        Console.WriteLine($"Remaining Ticket Quantity: {queriedFlight.RemainingTicketQuantity}");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Flight not found.");
    }
}


static void SortFlights()
{
    List<Flight> sortedFlights = flights.OrderBy(f => f.FlightNumber).ToList();

    if (sortedFlights.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Sorted Flights by Flight Number:");
        foreach (var flight in sortedFlights)
        {
            Console.WriteLine();
            Console.WriteLine($"Flight Number: {flight.FlightNumber}");
            Console.WriteLine($"Departure City: {flight.DepartureCity}");
            Console.WriteLine($"Arrival City: {flight.ArrivalCity}");
            Console.WriteLine($"Departure Time: {flight.DepartureTime}");
            Console.WriteLine($"Arrival Time: {flight.ArrivalTime}");
            Console.WriteLine($"Ticket Price: {flight.TicketPrice}");
            Console.WriteLine($"Fare Discount: {flight.FareDiscount}");
            Console.WriteLine($"Total Ticket Quantity: {flight.TotalTicketQuantity}");
            Console.WriteLine($"Remaining Ticket Quantity: {flight.RemainingTicketQuantity}");
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("No flights available to sort.");
    }
}


    static void CustomerMenu()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("                                                                      Customer           ");
        Console.WriteLine("                                                               ----------------------");
        Console.WriteLine();
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Book Ticket");
        Console.WriteLine("3. Refund Ticket");
        Console.WriteLine("4. Query Personal Information");
        Console.WriteLine("5. Back to Main Menu");
        Console.WriteLine();
        Console.Write("Select an option: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                RegisterCustomer();
                break;
            case 2:
                BookTicket();
                break;
            case 3:
                RefundTicket();
                break;
            case 4:
                QueryPersonalInformation();
                break;
            case 5:
                return;
            default:
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
}

static void RegisterCustomer()
{
    Console.WriteLine();
    Console.Write("Username: ");
    string username = Console.ReadLine();

    // Check if the username already exists
    if (customers.Any(c => c.Username == username))
    {
        Console.WriteLine();
        Console.WriteLine("Username already exists. Please choose a different username.");
        return;
    }

    Console.Write("Password: ");
    string password = Console.ReadLine();

    Console.Write("ID Card: ");
    string idCard = Console.ReadLine();

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Customer newCustomer = new Customer(username, password, idCard, name);
    customers.Add(newCustomer);

    Console.WriteLine();
    Console.WriteLine("Customer registered successfully.");
}


static void BookTicket()
{
    Console.WriteLine();
    Console.Write("Enter Flight Number: ");
    string flightNumber = Console.ReadLine();
    Flight flightToBook = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

    if (flightToBook != null)
    {
        if (flightToBook.RemainingTicketQuantity > 0)
        {
            Console.Write("Enter your Username: ");
            string username = Console.ReadLine();
            Customer bookingCustomer = customers.FirstOrDefault(c => c.Username == username);

            if (bookingCustomer != null)
            {
                var bookedFlights = new List<Flight>();
                var alreadyBooked = bookedFlights.FirstOrDefault(f => f.FlightNumber == flightNumber);

                if (alreadyBooked == null)
                {
                    flightToBook.RemainingTicketQuantity--;
                    bookedFlights.Add(flightToBook);
                    Console.WriteLine();

                    Console.WriteLine("Ticket Booked Successfully.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You Have Already Booked This Flight.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Customer Not Found.");
            }
        }
        else
        {
            Console.WriteLine("There Is No Available Tickets For This Flight.");
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Flight not found.");
    }
}


static void RefundTicket()
{
    Console.WriteLine();
    Console.Write("Enter Username: ");
    string username = Console.ReadLine();
    Customer customerToRefund = customers.FirstOrDefault(c => c.Username == username);

    if (customerToRefund != null)
    {
        Console.Write("Enter Flight Number to refund: ");
        string flightNumber = Console.ReadLine();
        Flight flightToRefund = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

        if (flightToRefund != null)
        {
            var bookedFlights = new List<Flight>();
            var bookedFlight = bookedFlights.FirstOrDefault(f => f.FlightNumber == flightNumber);

            if (bookedFlight != null)
            {
                flightToRefund.RemainingTicketQuantity++;
                bookedFlights.Remove(bookedFlight);

                Console.WriteLine();
                Console.WriteLine("Ticket Refunded Successfully.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ticket Refunded Successfully.");
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Flight not found.");
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Customer not found.");
    }
}


static void QueryPersonalInformation()
{
    Console.WriteLine();
    Console.Write("Enter Username: ");
    string username = Console.ReadLine();
    Customer queriedCustomer = customers.FirstOrDefault(c => c.Username == username);

    if (queriedCustomer != null)
    {
        Console.WriteLine();
        Console.WriteLine("Customer Information:");
        Console.WriteLine();
        Console.WriteLine($"Username: {queriedCustomer.Username}");
        Console.WriteLine($"ID Card: {queriedCustomer.IDCard}");
        Console.WriteLine($"Name: {queriedCustomer.Name}");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Customer not found.");
    }
}


    static void CheckCustomersOnFlight()
{
    Console.WriteLine();
    Console.Write("Enter Flight Number: ");
    string flightNumber = Console.ReadLine();

    Flight flightToCheck = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

    if (flightToCheck != null)
    {
        Console.WriteLine();
        Console.WriteLine("Customers on Flight:");
        var bookedFlights = new List<Flight>(); 

        foreach (Customer customer in customers)
        {
            if (bookedFlights.Any(f => f.FlightNumber == flightToCheck.FlightNumber))
            {
                Console.WriteLine();
                Console.WriteLine($"Username: {customer.Username}");
                Console.WriteLine($"ID Card: {customer.IDCard}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine();
            }
        }

        if (!bookedFlights.Any(f => f.FlightNumber == flightToCheck.FlightNumber))
        {
            Console.WriteLine();
            Console.WriteLine("No customers are booked on this flight.");
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Flight not found.");
    }
}

    static void LoadData()
{
    if (File.Exists("flights.txt"))
    {
        using (StreamReader reader = new StreamReader("flights.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] flightData = line.Split(',');
                if (flightData.Length == 8)
                {
                    Flight newFlight = new Flight(
                        flightData[0],
                        flightData[1],
                        flightData[2], 
                        DateTime.Parse(flightData[3]),
                        DateTime.Parse(flightData[4]), 
                        double.Parse(flightData[5]), 
                        double.Parse(flightData[6]), 
                        int.Parse(flightData[7]) 
                    );
                    flights.Add(newFlight);
                }
            }
        }
    }
    if (File.Exists("customers.txt"))
    {
        using (StreamReader reader = new StreamReader("customers.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] customerData = line.Split(',');
                if (customerData.Length == 4)
                {
                    Customer newCustomer = new Customer(
                        customerData[0], 
                        customerData[1], 
                        customerData[2], 
                        customerData[3] 
                    );
                    customers.Add(newCustomer);
                }
            }
        }
    }
}


    static void SaveData()
{
    using (StreamWriter writer = new StreamWriter("flights.txt"))
    {
        foreach (Flight flight in flights)
        {
            string line = string.Join(",",
                flight.FlightNumber,
                flight.DepartureCity,
                flight.ArrivalCity,
                flight.DepartureTime.ToString("yyyy-MM-dd HH:mm"),
                flight.ArrivalTime.ToString("yyyy-MM-dd HH:mm"),
                flight.TicketPrice.ToString(),
                flight.FareDiscount.ToString(),
                flight.TotalTicketQuantity.ToString()
            );
            writer.WriteLine(line);
        }
    }

    using (StreamWriter writer = new StreamWriter("customers.txt"))
    {
        foreach (Customer customer in customers)
        {
            string line = string.Join(",",
                customer.Username,
                customer.Password,
                customer.IDCard,
                customer.Name
            );
            writer.WriteLine(line);
        }
    }
}
}