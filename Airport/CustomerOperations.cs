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
            while (true)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Please Choose the operation to be made");
                Console.WriteLine("1)Search Flights");
                Console.WriteLine("2)Preview your bookings");
                Console.WriteLine("3)Exit the program");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        SearchFlights searchFlights = new SearchFlights();
                        searchFlights.SearchFlightMain(flights, bookings);
                    }
                    else if (input == 2)
                    {
                        if (bookings.Count == 0)
                        {
                            Console.WriteLine("You don't have any booking");
                        }
                        else
                        {
                            PreviewBookings p = new PreviewBookings();
                            p.PreviewBookingsMain(flights, bookings);
                        }

                    }
                    else if (input == 3) return;
                    else
                    {
                        Console.WriteLine("Please enter a valid option from the pevious");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            
        }
    }
}
