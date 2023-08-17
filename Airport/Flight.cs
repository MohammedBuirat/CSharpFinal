using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Flight
    {
        public Flight() { }

        public int Id { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureCountry { get; set; }
        public string ArrivalCountry { get; set; }
        private List<bool> Seats;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal StanderedPrice { get; set; }

        public Flight(int id, string departureAirport, string arrivalAirport, string departureCountry, string arrivalCountry, int seats, DateTime departureTime, DateTime arrivalTime, decimal standeredPrice)
        {
            Id = id;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            DepartureCountry = departureCountry;
            ArrivalCountry = arrivalCountry;
            Seats = new List<bool>(Enumerable.Repeat(false, seats));
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            StanderedPrice = standeredPrice;
        }

        public int NumberOfAvalibleSeats()
        {
            int avalibleSeats = Seats.Count(seat => !seat);
            return avalibleSeats;
        }

        public override string ToString()
        {
            
            return $"Flight {Id}: {DepartureAirport} to {ArrivalAirport} " +
                   $"Departure Time: {DepartureTime}, Arrival Time: {ArrivalTime} " +
                   $"Avalible Seats: {NumberOfAvalibleSeats()}, Price: {StanderedPrice:C}";
        }

        public int BookRandomSeat()
        {
            List<int> avalibleSeats = new List<int>();
            for (int i = 0; i < Seats.Count; i++)
            {
                if (!Seats[i])
                {
                    avalibleSeats.Add(i);
                }
            }
            Random random = new Random();

            int lowerBound = 0;
            int upperBound = avalibleSeats.Count;

            int randomInt = random.Next(lowerBound, upperBound);
            Seats[avalibleSeats[randomInt]] = true;
            return avalibleSeats[randomInt];
        }

        public bool BookSeat(int seat)
        {
            if (seat < 0 || seat > Seats.Count) return false;
            if (!Seats[seat])
            {
                Seats[seat] = true;
                return Seats[seat];
            }
            return false;

        }

        public bool SeatAvalible(int seat)
        {
            if (seat < 0 || seat > Seats.Count) return false;
            return !Seats[seat];
        }
        public void FreeSeat(int seat)
        {
            Seats[seat] = false;
        }

        public List<int> AvalibleSeats()
        {
            List<int> seats = Enumerable.Range(0, Seats.Count).Where(i => !Seats[i]).ToList();
            return seats;
        }



    }
}