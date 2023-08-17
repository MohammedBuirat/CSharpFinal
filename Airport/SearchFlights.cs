using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class SearchFlights
    {
        List<Booking> Bookings;
        public void SearchFlightMain(List<Flight> flights, List<Booking> bookings)
        {
            Bookings = bookings;
            while (true)
            {
                Console.WriteLine("Please pick from the following options");
                Console.WriteLine("1)Search");
                Console.WriteLine("2)Anywhere");
                Console.WriteLine("3)Return");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        Search(flights);
                        break;
                    }
                    else if (input == 2)
                    {
                        AnyWhere(flights);
                        break;
                    }
                    else if (input == 3) break;
                    else
                    {
                        Console.WriteLine("Pleas pick a valid option");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public void Search(List<Flight> flights)
        {
            string dCountry = "";
            string aCountry = "";
            string dAirport = "";
            string aAirport = "";
            int minPrice = 0;
            int maxPrice = int.MaxValue;
            DateTime? dDate = null;
            DateTime? aDate = null;

            while (true)
            {
                Console.WriteLine("The departing country");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic Country");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    Console.Write("Country name:");
                    dCountry = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The arrival country");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic Country");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    Console.Write("Country name:");
                    aCountry = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The departing airport");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic airport");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    Console.Write("Country name:");
                    dAirport = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The arrival airport");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic airport");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    Console.Write("Country name:");
                    aAirport = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The min flight price");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic price");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    Console.Write("the min price:");
                    minPrice = int.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The max flight price");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic price");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    Console.Write("the min price:");
                    maxPrice = int.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The flight departure date");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic date");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    int year = 2000;
                    int month = 2;
                    int day = 19;
                    Console.Write("Year:");
                    Console.WriteLine();
                    year = int.Parse(Console.ReadLine());
                    Console.Write("Month:");
                    Console.WriteLine();
                    month = int.Parse(Console.ReadLine());
                    Console.Write("Day:");
                    day = int.Parse(Console.ReadLine());
                    dDate = new DateTime(year, month, day);
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            while (true)
            {
                Console.WriteLine("The flight arrival date");
                Console.WriteLine("1)Any.");
                Console.WriteLine("2)Specefic date");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) break;
                else if (input == 2)
                {
                    int year = 2000;
                    int month = 2;
                    int day = 19;
                    Console.Write("Year:");
                    Console.WriteLine();
                    year = int.Parse(Console.ReadLine());
                    Console.Write("Month:");
                    Console.WriteLine();
                    month = int.Parse(Console.ReadLine());
                    Console.Write("Day:");
                    day = int.Parse(Console.ReadLine());
                    aDate = new DateTime(year, month, day);
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }

            List<Flight> searched = flights.Where(flight =>
            (flight.DepartureCountry.Contains(dCountry)) &&
            (flight.ArrivalCountry.Contains(aCountry)) &&
            (flight.DepartureAirport.Contains(dAirport)) &&
            (flight.ArrivalAirport.Contains(aAirport)) &&
            (flight.StanderedPrice >= minPrice) &&
            (flight.StanderedPrice <= maxPrice) &&
            flight.NumberOfAvalibleSeats() != 0).ToList();

            if (dDate.HasValue)
            {
                searched = searched.Where(flight => flight.DepartureTime.Date == dDate).ToList();
            }
            if (aDate.HasValue)
            {
                searched = searched.Where(flight => flight.ArrivalTime.Date == aDate).ToList();
            }
            SearchOperations(searched);
        }

        public void SearchOperations(List<Flight> flights)
        {
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
            while (true)
            {
                Console.WriteLine("Enter the id of the flight to book");
                Console.WriteLine("enter 0 to exit");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    break;
                }
                else
                {
                    if (flights.Any(flight => flight.Id == input))
                    {
                        BookFlight(flights.First(flight => flight.Id == input));
                        return;

                    }
                    else
                    {
                        Console.WriteLine("There is no flight with the given id");
                    }
                }
            }

        }
        public void BookFlight(Flight flight)
        {
            FlightClass flightClass;
            int seat;
            while (true)
            {
                Console.WriteLine("Please pick the class of the ticket");
                Console.WriteLine("1)Economy.");
                Console.WriteLine("2)Busniess.");
                Console.WriteLine("3)First Class");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    flightClass = FlightClass.Economy;
                    break;
                }
                if (input == 2)
                {
                    flightClass = FlightClass.Business;
                    break;
                }
                if (input == 3)
                {
                    flightClass = FlightClass.FirstClass;
                    break;
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }
            }
            List<int> seats = flight.AvalibleSeats();
            int temp = 0;
            Console.WriteLine("The list of avalible seats:");
            foreach (var avalbileSeats in seats)
            {
                Console.Write($"{avalbileSeats}  ");
                temp++;
                if (temp == 10)
                {
                    temp = 0;
                    Console.WriteLine();
                }
            }
            while (true)
            {
                Console.WriteLine("please pick a seat number or enter -1 to pick a random seat");
                int input = int.Parse(Console.ReadLine());
                if (input == -1)
                {
                    seat = flight.BookRandomSeat();
                    break;
                }
                else if (seats.Any(seat => seat == input))
                {
                    seat = input;
                    break;
                }
                else
                {
                    Console.WriteLine("Seat is no avalible or it does not exist");
                }

            }
            Bookings.Add(new Booking(flightClass, flight, seat));
            Console.WriteLine("Flight booked sucessfully");
        }
        public void AnyWhere(List<Flight> flights)
        {


            var countriesWithLeastPriceTickets = flights
                .GroupBy(flight => flight.DepartureCountry)
                .Select(group => new
                {
                    Country = group.Key,
                    LeastPriceTicket = group.OrderBy(flight => flight.StanderedPrice).Where(flight => flight.NumberOfAvalibleSeats() != 0).FirstOrDefault()
                })
                .ToList();
            foreach (var country in countriesWithLeastPriceTickets)
            {
                Console.WriteLine(country);
            }

        }
    }
}
