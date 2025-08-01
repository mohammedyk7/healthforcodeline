using hospitalsystem.Interface;
using hospitalsystem.models;
using hospitalsystem.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalsystem.Services
{
    public class SuperAdminService
    {

        public static void RunMainMenu()
        {
          
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║      WELCOME TO SILAF HOSPITAL SYSTEM      ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Super Admin Login                       ║");
                Console.WriteLine("║ 2. Doctor Login                            ║");
                Console.WriteLine("║ 3. Patient Signup                          ║");
                Console.WriteLine("║ 4. Patient Login                           ║");
                Console.WriteLine("║ 5. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1-5): ");

           




                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SuperAdmin superAdmin = new SuperAdmin("Main Admin", "admin@hospital.com", "admin123");
                        superAdmin.DisplayMenu();
                        break;

                    case "2":
                        Console.Write("Enter your email: ");
                        string dEmail = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string dPassword = Console.ReadLine();

                        Doctor? doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email == dEmail);
                        if (doctor != null)
                        {
                            IDoctorService dService = new DoctorService(doctor);
                            dService.DisplayDoctorMenu();
                        }
                        else
                        {
                            Console.WriteLine("❌ Invalid doctor credentials.");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        PatientSignup();
                        break;

                    case "4":
                        Console.Write("Enter your email: ");
                        string pEmail = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string pPassword = Console.ReadLine();

                        Patient? patient = HospitalData.Patients.FirstOrDefault(p => p.Email == pEmail );
                        if (patient != null)
                        {
                            IPatientService pService = new PatientService(patient);
                            pService.DisplayPatientMenu();
                        }
                        else
                        {
                            Console.WriteLine("❌ Invalid patient credentials.");
                            Console.ReadKey();
                        }
                        break;

                    case "5":
                        Console.WriteLine("👋 Exiting system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("⚠️ Invalid selection. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }








        public static void RunDoctorService()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║             DOCTOR SERVICE MENU            ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Doctor                           ║");
                Console.WriteLine("║ 2. View All Doctors                        ║");
                Console.WriteLine("║ 3. Update Doctor                           ║");
                Console.WriteLine("║ 4. Delete Doctor                           ║");
                Console.WriteLine("║ 5. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1-5): ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1": CreateDoctor(); break;
                    case "2": ViewAllDoctors(); break;
                    case "3": UpdateDoctor(); break;
                    case "4": DeleteDoctor(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("⚠️ Invalid selection.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CreateDoctor()
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            var doctor = new Doctor(name, email, clinicId);
            HospitalData.Doctors.Add(doctor);
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
            Console.WriteLine("✅ Doctor added.");
            Console.ReadKey();
        }

        private static void ViewAllDoctors()
        {
            if (HospitalData.Doctors.Count == 0)
            {
                Console.WriteLine("❌ No doctors found.");
            }
            else
            {
                foreach (var d in HospitalData.Doctors)
                    d.Display();
            }
            Console.ReadKey();
        }

        private static void UpdateDoctor()
        {
            Console.Write("Enter Doctor Email to update: ");
            string email = Console.ReadLine()!;
            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email == email);

            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            else
            {
                Console.Write("New Name: ");
                doctor.FullName = Console.ReadLine()!;
                Console.Write("New Clinic ID: ");
                doctor.ClinicId = int.Parse(Console.ReadLine()!);
                FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
                Console.WriteLine("✅ Doctor updated.");
            }
            Console.ReadKey();
        }

        private static void DeleteDoctor()
        {
            Console.Write("Enter Doctor Email to delete: ");
            string email = Console.ReadLine()!;
            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email == email);

            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            else
            {
                HospitalData.Doctors.Remove(doctor);
                FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
                Console.WriteLine("✅ Doctor deleted.");
            }
            Console.ReadKey();
        }



        public static void RunDepartmentService()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║           DEPARTMENT SERVICE MENU          ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Department                       ║");
                Console.WriteLine("║ 2. View All Departments                    ║");
                Console.WriteLine("║ 3. Update Department                       ║");
                Console.WriteLine("║ 4. Delete Department                       ║");
                Console.WriteLine("║ 5. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1-5): ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1": CreateDepartment(); break;
                    case "2": ViewAllDepartments(); break;
                    case "3": UpdateDepartment(); break;
                    case "4": DeleteDepartment(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("⚠️ Invalid selection.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CreateDepartment()
        {
            Console.Write("Enter Department ID: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Department Name: ");
            string name = Console.ReadLine()!;

            var dept = new Department(id, name);
            HospitalData.Departments.Add(dept);
            FileStorage.SaveToFile("departments.json", HospitalData.Departments);
            Console.WriteLine("✅ Department created.");
            Console.ReadKey();
        }

        private static void ViewAllDepartments()
        {
            if (HospitalData.Departments.Count == 0)
            {
                Console.WriteLine("❌ No departments found.");
            }
            else
            {
                foreach (var d in HospitalData.Departments)
                    d.Display();
            }
            Console.ReadKey();
        }

        private static void UpdateDepartment()
        {
            Console.Write("Enter Department ID to update: ");
            int id = int.Parse(Console.ReadLine()!);
            var dept = HospitalData.Departments.FirstOrDefault(d => d.Id == id);

            if (dept == null)
            {
                Console.WriteLine("❌ Department not found.");
            }
            else
            {
                Console.Write("New Name: ");
                dept.Name = Console.ReadLine()!;
                FileStorage.SaveToFile("departments.json", HospitalData.Departments);
                Console.WriteLine("✅ Department updated.");
            }
            Console.ReadKey();
        }

        private static void DeleteDepartment()
        {
            Console.Write("Enter Department ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            var dept = HospitalData.Departments.FirstOrDefault(d => d.Id == id);

            if (dept == null)
            {
                Console.WriteLine("❌ Department not found.");
            }
            else
            {
                HospitalData.Departments.Remove(dept);
                FileStorage.SaveToFile("departments.json", HospitalData.Departments);
                Console.WriteLine("✅ Department deleted.");
            }
            Console.ReadKey();
        }




        public static void RunAdminService()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║              ADMIN SERVICE MENU            ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Admin                            ║");
                Console.WriteLine("║ 2. View All Admins                         ║");
                Console.WriteLine("║ 3. Update Admin                            ║");
                Console.WriteLine("║ 4. Delete Admin                            ║");
                Console.WriteLine("║ 5. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1-5): ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1": CreateAdmin(); break;
                    case "2": ViewAllAdmins(); break;
                    case "3": UpdateAdmin(); break;
                    case "4": DeleteAdmin(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("⚠️ Invalid selection.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CreateAdmin()
        {
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            var admin = new Admin(name, email, password);
            HospitalData.Admins.Add(admin);
            FileStorage.SaveToFile("admins.json", HospitalData.Admins);
            Console.WriteLine("✅ Admin created.");
            Console.ReadKey();
        }

        private static void ViewAllAdmins()
        {
            if (HospitalData.Admins.Count == 0)
            {
                Console.WriteLine("❌ No admins found.");
            }
            else
            {
                foreach (var a in HospitalData.Admins)
                    a.Display();
            }
            Console.ReadKey();
        }

        private static void UpdateAdmin()
        {
            Console.Write("Enter Email of Admin to update: ");
            string email = Console.ReadLine()!;
            var admin = HospitalData.Admins.FirstOrDefault(a => a.Email == email);

            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
            }
            else
            {
                Console.Write("New Full Name: ");
                admin.FullName = Console.ReadLine()!;
                Console.Write("New Password: ");
                admin.Password = Console.ReadLine()!;
                FileStorage.SaveToFile("admins.json", HospitalData.Admins);
                Console.WriteLine("✅ Admin updated.");
            }
            Console.ReadKey();
        }

        private static void DeleteAdmin()
        {
            Console.Write("Enter Email of Admin to delete: ");
            string email = Console.ReadLine()!;
            var admin = HospitalData.Admins.FirstOrDefault(a => a.Email == email);

            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
            }
            else
            {
                HospitalData.Admins.Remove(admin);
                FileStorage.SaveToFile("admins.json", HospitalData.Admins);
                Console.WriteLine("✅ Admin deleted.");
            }
            Console.ReadKey();
        }
        public static void RunBranchDepartmentService()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║      ASSIGN DEPARTMENT TO BRANCH MENU      ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Assign Department to Branch             ║");
                Console.WriteLine("║ 2. View All Branch-Department Links        ║");
                Console.WriteLine("║ 3. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1-3): ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1": AssignDepartmentToBranch(); break;
                    case "2": ViewAllBranchDepartments(); break;
                    case "3": return;
                    default:
                        Console.WriteLine("⚠️ Invalid selection.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AssignDepartmentToBranch()
        {
            Console.Write("Enter Branch ID: ");
            int branchId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Department ID: ");
            int deptId = int.Parse(Console.ReadLine()!);

            var link = new BranchDepartment(branchId, deptId);
            HospitalData.BranchDepartments.Add(link);
            FileStorage.SaveToFile("branchDepartments.json", HospitalData.BranchDepartments);

            Console.WriteLine("✅ Department assigned to branch.");
            Console.ReadKey();
        }

        private static void ViewAllBranchDepartments()
        {
            if (HospitalData.BranchDepartments.Count == 0)
            {
                Console.WriteLine("❌ No assignments found.");
            }
            else
            {
                foreach (var link in HospitalData.BranchDepartments)
                {
                    Console.WriteLine($"Branch ID: {link.BranchId}  <-->  Department ID: {link.DepartmentId}");
                }
            }
            Console.ReadKey();
        }


        public static void PatientSignup()
        {
            Console.WriteLine("\n=== Patient Signup ===");

            Console.Write("Full Name: ");
            string fullName = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            Console.Write("National ID: ");
            string nationalId = Console.ReadLine()!;

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Gender: ");
            string gender = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine()!;

            var patient = new Patient(fullName, email, password, nationalId, age, gender, phone);

            HospitalData.Patients.Add(patient);
            FileStorage.SaveToFile("patients.json", HospitalData.Patients);

            Console.WriteLine("✅ Patient signed up successfully.");
            Console.ReadKey();
        }
    }
}
