using System;
using System.Collections.Generic;

namespace EXE_PROJECT.Models;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public int UserId { get; set; }

    public int ModuleId { get; set; }

    public string SubmissionUrl { get; set; }

    public decimal? Score { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public virtual Module Module { get; set; }

    public virtual User User { get; set; }
}
