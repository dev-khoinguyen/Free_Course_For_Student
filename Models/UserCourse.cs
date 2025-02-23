using System;
using System.Collections.Generic;

namespace EXE_PROJECT.Models;

public partial class UserCourse
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime? EnrolledAt { get; set; }

    public virtual Course Course { get; set; }

    public virtual User User { get; set; }
}
