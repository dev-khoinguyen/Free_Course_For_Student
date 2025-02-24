using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Free_Course_For_Student.Repository.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ElearningContext _context;
        public ProfileRepository(ElearningContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public List<UserCourse> GetUserCourses(int userId)
        {

            return _context.UserCourses
                .Where(uc => uc.UserId == userId)
                .Include(uc => uc.Course) // Phải Include Course để tránh null
                .ToList();
        }
        public List<Submission> GetUserScores(int userId)
        {
            return _context.Submissions
                .Where(s => s.UserId == userId)
                .Include(s => s.Module) // Lấy thông tin Module nếu cần hiển thị
                .ToList();
        }

    }
}