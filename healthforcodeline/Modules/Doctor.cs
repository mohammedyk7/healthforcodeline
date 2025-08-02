using hospitalsystem.models;
using System;
using System.Linq;

namespace hospitalsystem.models
{
    public class Doctor : User// Represents a doctor in the hospital system, inheriting from User
    {
        public int ClinicId { get; set; } = 0;// Identifier for the clinic the doctor is associated with
        public bool IsAvailable { get; set; } = true;// Indicates whether the doctor is available for appointments

        public Doctor() { }// Default constructor

        public Doctor(string fullName, string email)// Constructor with parameters for full name and email
            : base(fullName, email, "default123")
        {
            Role = "Doctor";
        }

        public Doctor(string fullName, string email, string password, int clinicId)// Constructor with parameters for full name, email, password, and clinic ID
            : base(fullName, email, password)// Calls the base class constructor to initialize common user properties
        {
            Role = "Doctor";
            ClinicId = clinicId;
            IsAvailable = true;
        }



      

             public override void DisplayMenu()// Displays the doctor's menu options
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║              DOCTOR MENU             ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1.    View My Appointments           ║");
                Console.WriteLine("║ 2.    Write Patient Record           ║");
                Console.WriteLine("║ 3.    View My Records                ║");
                Console.WriteLine("║ 4.    Set My Availability            ║");
                Console.WriteLine("║ 5.    Exit                           ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write(" Enter your choice (1-5): ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        ViewMyAppointments();// View the doctor's appointments
                        break;
                    case "2":
                        WritePatientRecord();// Write a new patient record
                        break;
                    case "3":
                        ViewMyRecords();// View the doctor's patient records
                        break;
                    case "4":
                        SetAvailability();// Set the doctor's availability
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public void ViewMyAppointments()// Displays the doctor's appointments
        {
            Console.WriteLine($"\nAppointments for Dr. {FullName}:\n");

            var myBookings = HospitalData.Bookings// Retrieves bookings where the doctor's email matches the current doctor's email
                .Where(b => b.DoctorEmail.Equals(Email, StringComparison.OrdinalIgnoreCase))// Filters bookings by the current doctor's email
                .ToList();// Converts the filtered bookings to a list

            if (myBookings.Count == 0)// Checks if there are no bookings for the doctor
            {
                Console.WriteLine("No appointments found.\n");
                return;
            }

            foreach (var booking in myBookings)// Iterates through each booking and displays its details
                booking.Display();

            Console.WriteLine($"[DEBUG] Current Doctor Email: {Email}");
            Console.WriteLine($"[DEBUG] Total Bookings: {HospitalData.Bookings.Count}");

            foreach (var b in HospitalData.Bookings)// Iterates through all bookings to display their doctor email
            {
                Console.WriteLine($"[DEBUG] Booking -> DoctorEmail: {b.DoctorEmail}");// Displays the doctor email associated with each booking
            }

            Console.ReadKey();  

        }

        public void ViewMyRecords()// Displays the doctor's patient records
        {
            var myRecords = HospitalData.Records.Where(r => r.DoctorName == FullName);// Filters records where the doctor's name matches the current doctor's full name
            foreach (var record in myRecords)// Iterates through each record and displays its details
                record.Display();

            Console.WriteLine($"[DEBUG] Current Doctor Name: {FullName}");// Displays the current doctor's full name for debugging purposes
            Console.WriteLine($"[DEBUG] Total Records: {HospitalData.Records.Count}");
            // Displays the total number of records for debugging purposes
            foreach (var r in HospitalData.Records)// Iterates through all records to display their doctor name
            {
                Console.WriteLine($"[DEBUG] Record -> DoctorName: {r.DoctorName}");
            }
            Console.ReadKey();
        }

        public void WritePatientRecord()// Prompts the doctor to enter details for a new patient record
        {
            Console.Write("Enter Record ID: ");
            int id = int.Parse(Console.ReadLine()!);// Parses the record ID from user input

            Console.Write("Enter Patient Name: ");
            string patient = Console.ReadLine()!;// Reads the patient's name from user input

            Console.Write("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine()!;// Reads the diagnosis from user input

            Console.Write("Enter Prescription: ");
            string prescription = Console.ReadLine()!;// Reads the prescription from user input

            var record = new PatientRecord(id, patient, FullName, diagnosis, prescription, DateTime.Now);// Creates a new PatientRecord object with the provided details
            HospitalData.Records.Add(record);// Adds the new record to the hospital data records list
            FileStorage.SaveToFile("records.json", HospitalData.Records);// Saves the updated records list to a JSON file

            Console.WriteLine("Patient record added successfully.\n");
        }

        public void CreateDoctor()// Prompts the user to enter details for a new doctor and adds it to the hospital data
        {
            Console.Write("Enter Doctor Name: ");// Prompts the user to enter the doctor's name
            string name = Console.ReadLine()!;

            Console.Write("Enter Doctor Email: ");// Prompts the user to enter the doctor's email
            string email = Console.ReadLine()!;

            Console.Write("Enter Clinic ID: ");// Prompts the user to enter the clinic ID where the doctor will work
            int clinicId = int.Parse(Console.ReadLine()!);

            var doctor = new Doctor(name, email, "123", clinicId);// Creates a new Doctor object with the provided details
            HospitalData.Doctors.Add(doctor);// Adds the new doctor to the hospital data doctors list
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);// Saves the updated doctors list to a JSON file

            Console.WriteLine("Doctor added successfully.\n");
        }

        public void Display()// Displays the doctor's information
        {
            Console.WriteLine($"Doctor Name: {FullName}, Email: {Email}, Clinic ID: {ClinicId}, Available: {(IsAvailable ? " Yes" : " No")}");// Displays the doctor's full name, email, clinic ID, and availability status
        }

        public static void ToggleDoctorAvailability()
        {
            Console.Write("Enter Doctor Email to toggle availability: ");
            string email = Console.ReadLine()!;

            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
                return;
            }

            doctor.IsAvailable = !doctor.IsAvailable;
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
            Console.WriteLine($"Doctor availability is now: {(doctor.IsAvailable ? "✅ Available" : "❌ Unavailable")}");
            Console.ReadKey();
        }

        public void SetAvailability()
        {
            Console.Write("Enter start time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime start))
            {
                Console.WriteLine("❌ Invalid start time.");
                return;
            }

            Console.Write("Enter end time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime end))
            {
                Console.WriteLine("❌ Invalid end time.");
                return;
            }

            if (end <= start)
            {
                Console.WriteLine("❌ End time must be after start time.");
                return;
            }

            var availability = new DoctorAvailability(Email, start, end);
            HospitalData.Availabilities.Add(availability);
            FileStorage.SaveToFile("availabilities.json", HospitalData.Availabilities);

            Console.WriteLine("✅ Availability set.");
            Console.ReadKey();
        }
    }





    }
