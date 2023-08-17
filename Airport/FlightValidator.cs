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

        private bool FlightIdValidation(int id, ref List<Flight> flights)
        {
            bool exist = flights.Any(flight => flight.Id == id);
            return !exist;
        }

        private bool SeatsValidation(int seats)
        {
            return (seats >= MinNumOfSeats && seats <= MaxNumOfSeats);
        }

        private bool DepartureTimeValidation(DateTime time)
        {
            return (time > DateTime.Now && time.Year < DateTime.Now.Year + 10);
        }

        private bool ArrivalTimeValidation(DateTime arrival, DateTime departure)
        {
            return (arrival > departure && arrival.Year <= DateTime.Now.Year + FutureYears);
        }

        private bool PriceValidation(decimal price)
        {
            return (price <= MaxPrice && price >= MinPrice);
        }
        public FlightStatus ValidFlight(Flight flight, List<Flight> flights)
        {
            FlightStatus resultCode;
            resultCode = 0;
            if (!FlightIdValidation(flight.Id, ref flights)) resultCode |= FlightStatus.IdReserved;

            if (!SeatsValidation(flight.SeatsCount())) resultCode |= FlightStatus.NumberOfSeatsOutOfBound;

            if (!DepartureTimeValidation(flight.DepartureTime)) resultCode |= FlightStatus.DepartureDateError;

            if (!ArrivalTimeValidation(flight.ArrivalTime, flight.DepartureTime)) resultCode |= FlightStatus.ArrivalDateError;

            if (!PriceValidation(flight.StanderedPrice)) resultCode |= FlightStatus.FlightPriceOutOfBound;

            if (resultCode == 0) resultCode = FlightStatus.Valid;

            return resultCode;

        }
    }
}