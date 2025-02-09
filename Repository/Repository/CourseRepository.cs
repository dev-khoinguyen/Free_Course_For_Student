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
        private readonly ELEARNINGContext _context;
        public CourseRepository( ELEARNINGContext context)
        {
            _context = context;
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            
        }

        public void DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourse()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCourseCount()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}