using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // IAdminService.cs
    public interface IAdminService
    {

        //This commit introduces the IAdminService interface which defines the basic
        //CRUD operations for Admin entities in the hospital system.The interface includes

        //add new admin users
        void CreateAdmin(Admin admin);

        //   to retrieve all admin records
        List<Admin> GetAllAdmins();

        //find an admin by email address
        Admin? GetAdminByEmail(string email);
    }
}
