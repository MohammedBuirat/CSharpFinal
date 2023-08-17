using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class PreviewBookings
    {
        List<Booking> Bookings;
        List<Flight> Flights;
        public void PreviewBookingsMain(List<Flight> flights, List<Booking> bookings)
        {
            Bookings = bookings;
            Flights = flights;
            Console.WriteLine("Here is your list of bookings");
            foreach (var book in Bookings)
            {
                Console.WriteLine(book.ToString());
            }
            while (true)
            {
                Console.WriteLine("pick a booking id to edit or cancel");
                Console.WriteLine("0 to exit");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    break;
                }
                else
                {
                    if (Bookings.Any(booking => booking.Id == input))
                    {
                        Booking book = Bookings.First(book => book.Id == input);
                        BookingSelected(book);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There is no booking with the given id");
                    }
                }
            }
        }

        public void BookingSelected(Booking booking)
        {
            while (true)
            {
                Console.WriteLine("1)delete the booking");
                Console.WriteLine("2)Modifiy the booking");
                Console.WriteLine("3)Cancel");
                int input = int.Parse((string)Console.ReadLine());
                if (input == 3) return;
                else if (input == 1)
                {
                    DeleteBooking(booking);
                }
                else if (input == 2)
                {
                    ModifiyBooking(booking);
                }
                else
                {
                    Console.WriteLine("Plese pick a valid option from the previous");
                }
            }
        }

        public void ModifiyBooking(Booking booking)
        {
            while (true)
            {
                Console.WriteLine($"1)Change the flight class current class = {booking.FlightClass}");
                Console.WriteLine("2)Change the booking date and time");
                Console.WriteLine("3)Return");
                int input = int.Parse((string)Console.ReadLine());
                if (input == 1)
                {
                    ChangeFlightClass(booking);
                    break;
                }
                else if (input == 2)
                {
                    ChangeFligheDate(booking);
                    break;
                }
                else if (input == 3)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Plese pick a valid option from the previous");
                }
            }
        }

        public void ChangeFlightClass(Booking booking)
        {
            FlightClass flightClass;
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
            booking.ChangeClass(flightClass);
        }

        public void ChangeFligheDate(Booking booking)
        {
            Flight flight = booking.Flight;
            int seat = booking.Seat;
            string dAirport = flight.DepartureAirport;
            string aAirport = flight.ArrivalAirport;
            var differentDate = Flights.Where(f => f.ArrivalAirport == aAirport && f.DepartureAirport == dAirport && f.Id != flight.Id).OrderBy(f => f.DepartureTime).ToList();
            foreach (var f in differentDate)
            {
                Console.WriteLine(f.ToString());
            }
            while (true)
            {
                Console.WriteLine("enter 0 to exit or enter flight id to change the flight date(price difference will be made)");
                int input = int.Parse(Console.ReadLine());
                if (input == 0) return;
                else if (differentDate.Any(flight => flight.Id == input))
                {
                    Flight temp = differentDate.First(flight => flight.Id == input);
                    Bookings.Add(new Booking(booking.FlightClass, temp, (temp.SeatAvalible(seat)) ? seat : temp.BookRandomSeat()));
                }
                else
                {
                    Console.WriteLine("There is no flight with the given id");
                }
            }
        }

        public void DeleteBooking(Booking booking)
        {
            booking.Flight.FreeSeat(booking.Seat);
            Bookings.Remove(booking);
        }
    }
}