using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Booking
    {
        //to store the number of booking made so far
        static int NumOfBooking = 1;

        public int Id { get; init; }
        public FlightClass FlightClass { get; set; }
        public Flight Flight { get; set; }
        public int Seat { get; set; }
        public DateTime BookingTime { get; init; }
        public decimal BookingPrice { get; set; }

        public Booking(FlightClass flightClass, Flight flight, int seat)
        {
            Id = NumOfBooking;
            NumOfBooking++;
            Flight = flight;
            BookingTime = DateTime.Now;
            Seat = seat;
            FlightClass = flightClass;
            BookingPrice = SetBookingPrice();
            Flight.BookSeat(seat);
        }

        public decimal SetBookingPrice()
        {
            if (FlightClass == FlightClass.Business) return Flight.BusniessClassPrice;
            else if (FlightClass == FlightClass.FirstClass) return Flight.FirstClassPrice;
            else return Flight.EconomyClassPrice;
        }

        public override string ToString()
        {
            return $"Booking id: {Id}  Flight: {Flight.ToString()}     Flight class: {FlightClass}    Booking price: {BookingPrice}   Seat num: {Seat}    Booking time: {BookingTime}";
        }

        public void ChangeBookingClass(FlightClass newFlightClass)
        {
            if (FlightClass == newFlightClass) return;
            FlightClass = newFlightClass;
            SetBookingPrice();
        }
    }
}