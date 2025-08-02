using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalsystem.Interface
{
    interface IClinicService
    {
        public interface IClinicService// Interface for clinic management operations
        {
            void AddClinic(Clinic clinic);// Add a new clinic
            List<Clinic> GetAllClinics();// Retrieve all clinics
            Clinic? GetById(int id);// Retrieve a clinic by its ID
            bool ClinicExists(int id);// Check if a clinic exists by its ID
        }
    }
}
