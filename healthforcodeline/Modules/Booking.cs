using System;

namespace hospitalsystem.models
{
    // Represents a booking (appointment) between a patient and a doctor at a specific clinic and date

    public class Booking
    {
        // Unique identifier for the booking

        public int Id { get; set; }
        // Email of the patient who made the booking

        public string PatientEmail { get; set; }
        // Email of the doctor assigned to the booking

        public string DoctorEmail { get; set; }
        // ID of the clinic where the appointment is scheduled

        public int ClinicId { get; set; }
        // Date and time of the appointment

        public DateTime AppointmentDate { get; set; }

        public bool IsCancelled { get; set; } = false;
        public string? CancellationReason { get; set; }

        public Booking() { }

        public Booking(int id, string patientEmail, string doctorEmail, int clinicId, DateTime appointmentDate)
        {
            Id = id;
            PatientEmail = patientEmail;
            DoctorEmail = doctorEmail;
            ClinicId = clinicId;
            AppointmentDate = appointmentDate;
        }

        public void Cancel(string reason = "")
        {
            IsCancelled = true;
            CancellationReason = reason;
        }

        public void Display()
        {
            Console.WriteLine($"📋 Booking #{Id}: Patient {PatientEmail} with Dr. {DoctorEmail} at Clinic {ClinicId} on {AppointmentDate}");

            if (IsCancelled)
            {
                Console.WriteLine($"❌ CANCELLED - Reason: {CancellationReason ?? "Not specified"}");
            }
        }
    }
}
