using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // ISuperAdminService.cs
    public interface ISuperAdminService
    {
        //register new super admin accounts
        void CreateSuperAdmin(SuperAdmin superAdmin);
        //to list all super admins
        List<SuperAdmin> GetAllSuperAdmins();
        // find admins by email
        SuperAdmin? GetSuperAdminByEmail(string email);

        // Additional methods based on your diagram:
        void CreateBranch(Branch branch);
        // add new hospital branches
        void AssignDepartmentToBranch(int departmentId, int branchId);
        void AssignBranchToDepartment(int branchId, int departmentId);
        void AssignDoctorToClinic(int doctorId, int clinicId);

        List<Branch> GetAllBranches();
        List<Department> GetAllDepartments();
        List<Doctor> GetAllDoctors();
    }
}
