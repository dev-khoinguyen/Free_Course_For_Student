using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourse();
        public Course GetCourseById(int id);
        public int GetCourseCount();
        public void AddCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(int id);
    }
}