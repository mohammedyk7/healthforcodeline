﻿using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface



    //The interface enables complete system administration capabilities including
//user management, organizational structure configuration, and resource assignment,
//following the system architecture requirements.
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

        // add new hospital branches
        void CreateBranch(Branch branch);
      
        void AssignDepartmentToBranch(int departmentId, int branchId);
        void AssignBranchToDepartment(int branchId, int departmentId);
        void AssignDoctorToClinic(int doctorId, int clinicId);
        //list all branches
        List<Branch> GetAllBranches();

        //for department enumeration
        List<Department> GetAllDepartments();
        // doctor directory access
        List<Doctor> GetAllDoctors();
    }
}
