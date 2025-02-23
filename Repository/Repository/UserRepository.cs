using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;

namespace Free_Course_For_Student.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ElearningContext _context;
        public UserRepository(ElearningContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }


        public User Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username && x.PasswordHash == password);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}