using System;
using System.Collections.Generic;

namespace EXE_PROJECT.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; }

    public int Position { get; set; }

    public string DocUrl { get; set; }

    public string VideoUrl { get; set; }

    public string Description { get; set; }

    public bool? IsFinished { get; set; }

    public virtual Course Course { get; set; }

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
