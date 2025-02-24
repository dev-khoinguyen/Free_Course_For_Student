using System.Collections.Generic;
using EXE_PROJECT.Models;

namespace EXE_PROJECT.Models // Đúng với cấu trúc thư mục
{
    public class ProfileViewModel
    {
        public User User { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}
