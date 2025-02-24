using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;

namespace Free_Course_For_Student.Repository.Repository
{
    public class CourseRepository : ICourseRepository
    {
          private readonly ElearningContext _context;

        public CourseRepository(ElearningContext context)
        {
            _context = context;
        }

        // Lấy tất cả khóa học
        public List<Course> GetAllCourse()
        {
            return _context.Courses.ToList();
        }

        // Lấy khóa học theo ID
        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        // Thêm khóa học mới
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // Cập nhật thông tin khóa học
        public void UpdateCourse(Course course)
        {
            var existingCourse = _context.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Title = course.Title;
                existingCourse.Description = course.Description;
                existingCourse.GroupChatUrl = course.GroupChatUrl;
                _context.SaveChanges();
            }
        }

        // Xóa khóa học
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public int GetCourseCount()
        {
            throw new NotImplementedException();
        }
    }
}