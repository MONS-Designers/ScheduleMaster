using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class ScheduleSubject
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    public int TeacherId { get; set; }

    public int PlacementStatusId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartHour { get; set; }

    public TimeOnly EndHour { get; set; }

    public int SubjectId { get; set; }

    public virtual PlacementStatus PlacementStatus { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual ICollection<StudentSubjectAssessment> StudentSubjectAssessments { get; set; } = new List<StudentSubjectAssessment>();

    public virtual ICollection<StudentSubjectTask> StudentSubjectTasks { get; set; } = new List<StudentSubjectTask>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
