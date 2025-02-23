using System;
using System.Collections.Generic;

namespace EXE_PROJECT.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string GroupChatUrl { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
