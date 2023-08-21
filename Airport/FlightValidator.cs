using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class FlightValidator
    {
        public static int MaxNumOfSeats = 1000;
        public static int MinNumOfSeats = 1;
        public static int FutureYears = 10;
        public static decimal MaxPrice = int.MaxValue;
        public static decimal MinPrice = 1;
        public static bool NumOfSeatsRequired = true;
        public static bool DepartureAirportRequired = true;
        public static bool ArrivalAirportRequired = true;
        public static bool PriceRequired = true;
        public static bool DepartureTimeRequired = true;
        public static bool ArrivalTimeRequired = true;

        public FlightStatus ValidateFlight(Flight flight)
        {
            FlightStatus status = FlightStatus.Valid;
            if (NumOfSeatsRequired)
            {
                status |= (ValidateSeats(flight.NumberOfSeats())) ? 0 : FlightStatus.NumberOfSeatsError;
            }
            if (DepartureAirportRequired)
            {
                status |= (ValidateAirport(flight.DepartureAirport)) ? 0 : FlightStatus.FlightAirportError;
            }
            if (ArrivalAirportRequired)
            {
                status |= (ValidateAirport(flight.ArrivalAirport)) ? 0 : FlightStatus.FlightAirportError;
            }
            if (PriceRequired)
            {
                status |= (ValidateAllPrices(flight.EconomyClassPrice, flight.BusniessClassPrice, flight.FirstClassPrice)) ? 0 : FlightStatus.FlightPriceError;
            }
            if (DepartureTimeRequired)
            {
                status |= ValidateDate(flight.DepartureTime) ? 0 : FlightStatus.DepartureDateError;
            }
            if (ArrivalTimeRequired)
            {
                status |= ValidateDate(flight.ArrivalTime) ? 0 : FlightStatus.ArrivalDateError;
            }
            return status;
        }

        public bool ValidateSeats(int? seats)
        {
            if (seats == null) return false;
            if (seats > MaxPrice || seats < MinPrice) return false;
            return true;
        }

        public bool ValidateDate(DateTime? date)
        {
            if (date == null) return false;
            if (date < DateTime.Now) return false;
            DateTime allowedFutureYears = DateTime.Now.AddYears(FutureYears);
            if (date > allowedFutureYears) return false;
            return true;
        }

        public bool ValidateAllPrices(decimal? economyPrice, decimal? businessPrice, decimal? firstClassPrce)
        {
            return ValidatePrice(economyPrice) && ValidatePrice(businessPrice) && ValidatePrice(firstClassPrce);
        }

        public bool ValidatePrice(decimal? price)
        {
            if (price == null) return false;
            if (price < MinPrice || price > MaxPrice) return false;
            return true;
        }

        public bool ValidateAirport(Airport airport)
        {
            if (airport == null || airport.Name == "") return false;
            return true;
        }
        public void PrintRequiredValidation()
        {
            Console.WriteLine("Number of seats:");
            Console.WriteLine((NumOfSeatsRequired) ? "Required" : "Not Required");
            Console.WriteLine($"Range from {MinNumOfSeats} to {MaxNumOfSeats}");
            Console.WriteLine("Price of flight:");
            Console.WriteLine((PriceRequired) ? "Required" : "Not Required");
            Console.WriteLine($"Range from {MinPrice} to {MaxPrice}");
            Console.WriteLine("Departure date");
            Console.WriteLine((DepartureTimeRequired) ? "Required" : "Not Required");
            Console.WriteLine($"Range from today to {FutureYears} years");
            Console.WriteLine("Arrival date");
            Console.WriteLine((ArrivalTimeRequired) ? "Required" : "Not Required");
            Console.WriteLine($"Range from today to {FutureYears} years");
            Console.WriteLine("Departure airport");
            Console.WriteLine((DepartureAirportRequired) ? "Required" : "Not Required");
            Console.WriteLine("Free text");
            Console.WriteLine("Arrival airport");
            Console.WriteLine((ArrivalAirportRequired) ? "Required" : "Not Required");
            Console.WriteLine("Free text");
        }

    }
}
