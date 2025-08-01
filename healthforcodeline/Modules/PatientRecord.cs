﻿namespace hospitalsystem.models
{    // Represents a medical record for a patient, including visit details, diagnosis, and prescription

    public class PatientRecord
    {
        // Unique identifier for the patient record

        public int Id { get; set; }
        // Name of the patient (can be changed to PatientEmail or ID for better tracking)

        public string PatientName { get; set; }
        // Name of the doctor who handled the visit

        public string DoctorName { get; set; }
        // Diagnosis provided by the doctor

        public string Diagnosis { get; set; }
        // Prescription given to the patient

        public string Prescription { get; set; }
        // Date of the visit

        public DateTime VisitDate { get; set; }
        // Constructor to initialize the patient record

        public PatientRecord(int id, string patientName, string doctorName, string diagnosis, string prescription, DateTime visitDate)
        {
            Id = id;
            PatientName = patientName;
            DoctorName = doctorName;
            Diagnosis = diagnosis;
            Prescription = prescription;
            VisitDate = visitDate;
        }
        // Display the record details in a readable format

        public void Display()
        {
            Console.WriteLine($"\nRecord #{Id}: {PatientName} | Dr. {DoctorName} | {VisitDate.ToShortDateString()}");
            Console.WriteLine($"Diagnosis: {Diagnosis}");
            Console.WriteLine($"Prescription: {Prescription}\n");
        }
    }
}
