using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class StudentSubjectAssessment
{
    public int Id { get; set; }

    public int? Mark { get; set; }

    public string? Assessment { get; set; }

    public int PresenceId { get; set; }

    public int ScheduleSubjectId { get; set; }

    public int StudentId { get; set; }

    public virtual Presence Presence { get; set; } = null!;

    public virtual ScheduleSubject ScheduleSubject { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
