using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport
{
    internal class Booking
    {
        int num = 1;
        public int Id { get; init; }
        public FlightClass FlightClass { get; set; }
        public Flight Flight { get; set; }
        public int Seat { get; set; }
        public DateTime BookingTime { get; init; }
        public decimal BookingPrice { get; set; }

        public Booking(FlightClass flightClass, Flight flight, int seat, DateTime bookingTime, decimal bookingPrice)
        {
            Id = num;
            num++;
            FlightClass = flightClass;
            Flight = flight;
            Seat = seat;
            BookingTime = bookingTime;
            BookingPrice = bookingPrice;
        }

        public Booking(int id, Flight flight, FlightClass flightClass, int seat)
        {
            this.Id = id;
            this.FlightClass = flightClass;
            this.Flight = flight;
            this.Seat = seat;
            BookingTime = DateTime.Now;
            SetPrice(flightClass);
        }

        public void SetPrice(FlightClass flightClass)
        {
            if (flightClass == FlightClass.Economy) BookingPrice = Flight.StanderedPrice;
            else if (flightClass == FlightClass.Business) BookingPrice = Flight.StanderedPrice * (decimal)1.2;
            else this.BookingPrice = Flight.StanderedPrice * 2;
        }

        public override string ToString()
        {
            return $"ID {Id}    Class {FlightClass}    Seat {Seat}      Departure Country {Flight.DepartureCountry}    Arrival Country {Flight.ArrivalCountry}  " +
                $"Departure Date {Flight.DepartureTime}    Booking price {BookingPrice}";
        }

        public void ChangeClass(FlightClass flightClass)
        {
            SetPrice(flightClass);
        }

    }
}
