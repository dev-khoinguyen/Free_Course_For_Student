using System;
using System.Collections.Generic;

#nullable disable

namespace EXE_PROJECT.Models
{
    public partial class Course
    {
        public Course()
        {
            Certificates = new HashSet<Certificate>();
            UserCourses = new HashSet<UserCourse>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string LinkVideo { get; set; }
        public string LinkDoc { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
