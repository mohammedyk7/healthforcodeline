using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalsystem.models
{
    public class DoctorAvailability// Represents the availability of a doctor
    {
        public string DoctorEmail { get; set; }// Email of the doctor
        public DateTime StartTime { get; set; }  // Start time of the doctor's availability
        public DateTime EndTime { get; set; }// End time of the doctor's availability

        public DoctorAvailability() { }// Default constructor

        public DoctorAvailability(string email, DateTime start, DateTime end)// Constructor with parameters for doctor's email, start time, and end time
        {
            DoctorEmail = email;// Initialize the doctor's email
            StartTime = start;// Initialize the start time of availability
            EndTime = end;// Initialize the end time of availability
        }

        public void Display()//display doctors availability
        {

            {
                Console.WriteLine($" {StartTime} to {EndTime}");
            }
        }
    }
}
