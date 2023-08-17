using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class CustomerOperations
    {
        public void CustomerMain(List<Flight> flights, List<Booking> bookings)
        {
            Console.WriteLine("Please Chose the operation to be made");
            Console.WriteLine("1)Search Flights");
            Console.WriteLine("2)Preview your bookings");
            Console.WriteLine("3)Exit the program");
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    SearchFlights searchFlights = new SearchFlights();
                    searchFlights.SearchFlightMain(flights);
                    CustomerMain(flights, bookings);

                }
                else if (input == 2)
                {
                    PreviewBookings p = new PreviewBookings();
                    p.PreviewBookingsMain(flights, bookings);
                }
                else if (input == 3) return;
                else
                {
                    Console.WriteLine("Please enter a valid option from the pevious");
                    CustomerMain(flights, bookings);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
