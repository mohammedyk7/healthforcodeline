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
            void AddClinic(Clinic clinic);
            List<Clinic> GetAllClinics();
            Clinic? GetById(int id);
            bool ClinicExists(int id);
        }
    }
}
