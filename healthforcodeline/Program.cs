using hospitalsystem.Interface;
using hospitalsystem.models;
using hospitalsystem.services;
using hospitalsystem.Services;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load data from files
        HospitalData.Doctors = FileStorage.LoadFromFile<Doctor>("doctors.json");
        HospitalData.Patients = FileStorage.LoadFromFile<Patient>("patients.json");
        HospitalData.Bookings = FileStorage.LoadFromFile<Booking>("bookings.json");
        HospitalData.Records = FileStorage.LoadFromFile<PatientRecord>("records.json");
        HospitalData.Branches = FileStorage.LoadFromFile<Branch>("branches.json");
        HospitalData.Departments = FileStorage.LoadFromFile<Department>("departments.json");
        HospitalData.Clinics = FileStorage.LoadFromFile<Clinic>("clinics.json");

        // Ensure at least one test patient exists
        if (!HospitalData.Patients.Any(p => p.Email == "yusuf@patient.com"))
        {
            HospitalData.Patients.Add(new Patient("Yusuf", "yusuf@patient.com", "123"));
            FileStorage.SaveToFile("patients.json", HospitalData.Patients);
        }

    



        SuperAdminService.RunMainMenu();

   

}
  

}

