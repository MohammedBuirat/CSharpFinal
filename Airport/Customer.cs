using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Customer
    {
        public static int NumOfCustomers = 1;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; init; }
        public DateTime DateOfRegisteration { get; }
        public DateTime DateOfBirth { get; set; }
        private List<Booking> Bookings;
        public decimal MoneyDue { get; set; }
        //i can add more fields but thoose are more than enough to get the require understanding perhaps i wll make a class person too to make the 
        //customer inherit from

        public Customer(string firstName, string lastName, DateTime dateOfBirth, List<Booking> bookings)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Bookings = bookings;
            MoneyDue = 0;
            DateOfRegisteration = DateTime.Now;
            Id = NumOfCustomers;
            NumOfCustomers += 1;
        }

        public Booking? FindBookingByBookingId(int id)
        {
            return Bookings.FirstOrDefault(booking => booking.Id == id);
        }
        public void AddBooking(Booking booking)
        {
            if (Bookings.Any(book => book == booking)) return;
            Bookings.Add(booking);
            MoneyDue += booking.BookingPrice;
        }

        public bool DeleteBooking(int id)
        {
            Booking? booking = FindBookingByBookingId(id);
            if (booking == null) return false;
            MoneyDue -= Bookings.First(booking => booking.Id == id).BookingPrice;
            Bookings.RemoveAll(booking => booking.Id == id);
            return true;
        }

        public void ChangeBookingClass(int id, FlightClass flightClass)
        {
            Booking? booking = FindBookingByBookingId(id);
            if (booking == null) return;
            else booking.ChangeBookingClass(flightClass);
        }
    }
}
