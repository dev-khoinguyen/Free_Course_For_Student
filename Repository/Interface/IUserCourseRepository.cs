using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface IUserCourseRepository
    {
        public void AddUserCourse(int userId, int courseId);
        public void DeleteUserCourse(UserCourse userCourse);
        public void UpdateUserCourse(UserCourse userCourse);
        public List<UserCourse> GetAllUserCourse();
        public UserCourse GetUserCourseById(int id);
        public List<UserCourse> GetUserCourseByUserId(int id);
        public List<UserCourse> GetUserCourseByCourseId(int id);
    }
}