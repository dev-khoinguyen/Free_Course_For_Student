using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface IProfileRepository
    {
        User GetUserById(int userId);
        List<UserCourse> GetUserCourses(int userId);
        List<Submission> GetUserScores(int userId);
    }
}