using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Flight
    {
        public int Id { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        private List<bool> Seats;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal FirstClassPrice { get; set; }
        public decimal BusniessClassPrice { get; set; }
        public decimal EconomyClassPrice { get; set; }

        public Flight(int id, Airport departureAirport, Airport arrivalAirport, int seats, DateTime departureTime, DateTime arrivalTime, decimal firstClassPrice, decimal busniessClassPrice, decimal economyClassPrice)
        {
            Id = id;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            Seats = Enumerable.Range(0, seats).Select(seat => true).ToList();
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            FirstClassPrice = firstClassPrice;
            BusniessClassPrice = busniessClassPrice;
            EconomyClassPrice = economyClassPrice;
        }

        public bool BookSeat(int seat)
        {
            if (seat < 0 || seat > Seats.Count()) return false;
            if (!Seats[seat]) return false;
            Seats[seat] = true;
            return true;
        }

        public bool SeatAvailble(int seat)
        {
            return Seats[seat];
        }

        public int NumberOfAvalibleSeats()
        {
            return Seats.Where(seat => true).Count();
        }

        public int NumberOfSeats()
        {
            return Seats.Count();
        }

        public List<int>? RetriveAvalibleSeats()
        {
            return Enumerable.Range(0, Seats.Count()).Where(index => Seats[index]).ToList();
        }

        public void FreeSeat(int seat)
        {
            Seats[seat] = true;
        }

        public override string ToString()
        {
            return $"Departing Airport: {DepartureAirport.ToString()}     Arrival Airport: {ArrivalAirport.ToString()}" +
                $"Departure time: {DepartureTime.ToString()}    Arrival time: {ArrivalTime.ToString()}  Economy price: {EconomyClassPrice}" +
                $"Bussines Pirce: {BusniessClassPrice}     First Class price: {FirstClassPrice}";
        }
    }
}
