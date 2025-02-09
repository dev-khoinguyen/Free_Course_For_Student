using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        public List<User> GetAllUser();
        public User GetUserById(int id);
        public User Login(string username, string password);
    }
}