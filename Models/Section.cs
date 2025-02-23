using System;
using System.Collections.Generic;

namespace EXE_PROJECT.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public int ModuleId { get; set; }

    public string Title { get; set; }

    public string VideoUrl { get; set; }

    public string DocUrl { get; set; }

    public string SubmissionUrl { get; set; }

    public int Position { get; set; }

    public virtual Module Module { get; set; }
}
