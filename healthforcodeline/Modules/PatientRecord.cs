namespace hospitalsystem.models
{    // Represents a medical record for a patient, including visit details, diagnosis, and prescription

    public class PatientRecord
    {
        // Unique identifier for the patient record

        public int Id { get; set; }
        // Name of the patient (can be changed to PatientEmail or ID for better tracking)

        public string PatientName { get; set; }
        // Name of the doctor who handled the visit

        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public DateTime VisitDate { get; set; }

        public PatientRecord(int id, string patientName, string doctorName, string diagnosis, string prescription, DateTime visitDate)
        {
            Id = id;
            PatientName = patientName;
            DoctorName = doctorName;
            Diagnosis = diagnosis;
            Prescription = prescription;
            VisitDate = visitDate;
        }

        public void Display()
        {
            Console.WriteLine($"\nRecord #{Id}: {PatientName} | Dr. {DoctorName} | {VisitDate.ToShortDateString()}");
            Console.WriteLine($"Diagnosis: {Diagnosis}");
            Console.WriteLine($"Prescription: {Prescription}\n");
        }
    }
}
