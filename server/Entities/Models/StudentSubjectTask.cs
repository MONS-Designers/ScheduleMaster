using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class StudentSubjectTask
{
    public int Id { get; set; }

    public int? Mark { get; set; }

    public string? Assessment { get; set; }

    public string? LinkToSendAnswers { get; set; }

    public int StudentId { get; set; }

    public int ScheduleSubjectId { get; set; }

    public int TaskId { get; set; }

    public virtual ScheduleSubject ScheduleSubject { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
