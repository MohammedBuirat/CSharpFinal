namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagerLogIn();
        }

        static void ManagerLogIn()
        {
            ManagerValidation managerValidation = new ManagerValidation();
            managerValidation.SetValidation();
            LoadFlights loadFlights = new LoadFlights();
            bool valid;
            List<Flight> flights = loadFlights.LoadData(out valid);
            if (valid)
            {
                CustomerLogIn(flights);
            }
            else
            {
                Console.WriteLine("Data file is facing some errors fix them to match the desired constraints");
            }
        }

        static void CustomerLogIn(List<Flight> flights)
        {
            List<Booking> bookings = new List<Booking>();
            CustomerOperations customerOperations = new CustomerOperations();
            Console.WriteLine("Welcome to AirPalestina");
            customerOperations.CustomerMain(flights, bookings);

        }
    }
}