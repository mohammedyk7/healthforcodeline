using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hospitalsystem.Interface
{
    interface IBookingService
    {
        // managing patient bookings in the hospital system. The interface includes
        public interface IBookingService
        {
            void AddBooking(Booking booking);
            List<Booking> GetAllBookings();
            List<Booking> GetBookingsByPatient(string patientName);
        }

    }
}
