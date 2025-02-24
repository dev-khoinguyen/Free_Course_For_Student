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
        public void AddUserCourse(int? userId, int courseId)
        {
            var userCourse = new UserCourse
            {
                UserId = userId.Value,
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

        public bool IsJoin(int courseId, int? userId)
        {
            return _context.UserCourses.Any(s => s.CourseId == courseId && s.UserId == userId);
        }

        public void UpdateCourseAndFinishCourse()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourseCount(int courseId, int? userId)
        {
            var userCourse = _context.UserCourses.FirstOrDefault(uc => uc.CourseId == courseId && uc.UserId == userId);
            if (userCourse != null)
            {
                // Đếm tổng số module thuộc khóa học này
                int totalModules = _context.Modules.Count(m => m.CourseId == courseId);
                userCourse.AllModule = totalModules;

                _context.SaveChanges();
            }
        }

        public void UpdateFinishCourse(int courseId, int? userId)
        {
            var userCourse = _context.UserCourses.FirstOrDefault(uc => uc.CourseId == courseId && uc.UserId == userId);
            if (userCourse != null)
            {
                // Đếm số module có bài nộp được duyệt (Status = "Approved")
                int approvedModules = _context.Submissions
                    .Where(s => s.Module.CourseId == courseId && s.UserId == userId && s.Status == "Approved")
                    .Select(s => s.ModuleId)
                    .Distinct()
                    .Count();

                userCourse.FinishedModule = approvedModules;

                _context.SaveChanges();
            }
        }


        public void UpdateUserCourse(UserCourse userCourse)
        {
            throw new NotImplementedException();
        }
    }
}