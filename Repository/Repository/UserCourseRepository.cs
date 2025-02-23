using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;

namespace Free_Course_For_Student.Repository.Repository
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly ElearningContext _context;
        public UserCourseRepository(ElearningContext context)
        {
            _context = context;
        }
        public void AddUserCourse(int userId, int courseId)
        {
            var userCourse = new UserCourse
            {
                UserId = userId,
                CourseId = courseId,
                EnrolledAt = DateTime.UtcNow // Lưu thời gian đăng ký (tùy chọn)
            };

            _context.UserCourses.Add(userCourse);
            _context.SaveChanges();
        }


        public void DeleteUserCourse(UserCourse userCourse)
        {
            throw new NotImplementedException();
        }

        public List<UserCourse> GetAllUserCourse()
        {
            throw new NotImplementedException();
        }

        public List<UserCourse> GetUserCourseByCourseId(int id)
        {
            throw new NotImplementedException();
        }

        public UserCourse GetUserCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserCourse> GetUserCourseByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserCourse(UserCourse userCourse)
        {
            throw new NotImplementedException();
        }
    }
}