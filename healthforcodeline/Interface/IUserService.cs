using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{//IUserService interface for core user management
    public interface IUserService
    {
        void CreateUser(User user);// user registration and account creation
        User? GetUserByEmail(string email);
        List<User> GetAllUsers();
    }
}