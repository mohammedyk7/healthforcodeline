﻿namespace hospitalsystem.models
{      // Admin class inherits from User and adds specific functionality for Admins

    public class Admin : User
    {
        // Parameterless constructor for file deserialization or default initialization

        public Admin() { }
        // Constructor for creating a new Admin with full name, email, and password

        public Admin(string fullName, string email, string password)
    : base(fullName, email, password)
        {
            Role = "Admin";
        }
        // Unique identifier for the admin

        public string Id { get; set; } = Guid.NewGuid().ToString();

        // DisplayMenu method shows options specific to Admin
        public override void DisplayMenu()
        {
            while (true)
            {
                // Display Admin menu UI

                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║                ADMIN MENU            ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║    1. Assign Doctor to Clinic        ║");
                Console.WriteLine("║   2. View All Doctors                ║");
                Console.WriteLine("║    3. Exit                           ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write(" Enter your choice (1-3): ");

                string choice = Console.ReadLine()!;
                Console.Clear();
                // Handle user input

                switch (choice)
                {
                    case "1":
                        AssignDoctorToClinic();
                        break;
                    case "2":
                        if (HospitalData.Doctors.Count == 0)
                        {
                            Console.WriteLine("No doctors found.");
                        }
                        else
                        {
                            foreach (var doc in HospitalData.Doctors)
                                Console.WriteLine($"👨‍⚕️ {doc.FullName} - Email: {doc.Email}, Clinic ID: {doc.ClinicId}");
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
        }


        // Method to assign a doctor to a clinic

        public void AssignDoctorToClinic()
        {
            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!;
            // Find the doctor by email (case insensitive)

            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            else
            {
                Console.Write("Enter New Clinic ID: ");
                int clinicId = int.Parse(Console.ReadLine()!);// Read new clinic ID

                doctor.ClinicId = clinicId; 
                                            // Update the doctor's clinic assignment

                // Save updated doctor list to file

                FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);

                Console.WriteLine($"✅ Doctor {doctor.FullName} assigned to Clinic {clinicId}.");
            }

            Console.ReadKey();
        }


    }
}
