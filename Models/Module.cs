using System;
using System.Collections.Generic;

namespace EXE_PROJECT.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; }

    public int Position { get; set; }

    public virtual Course Course { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
