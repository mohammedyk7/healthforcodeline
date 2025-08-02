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
            // create new appointment records
            void AddBooking(Booking booking);
            // to retrieve all booking entries
            List<Booking> GetAllBookings();
            //to filter bookings by patient name

            List<Booking> GetBookingsByPatient(string patientName);
        }

    }
}
