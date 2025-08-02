using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // IDepartmentService.cs
    public interface IDepartmentService// Interface for department management operations
    {
        void CreateDepartment(Department department);// Create a new department
        List<Department> GetAllDepartments();// Retrieve all departments
        Department? GetDepartmentById(int id);// Retrieve a department by its ID
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
    }
}