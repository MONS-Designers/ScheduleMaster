using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Subject
{
    public int Id { get; set; }

    public int SubjectCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; } = new List<ScheduleSubject>();

    public virtual SubjectCategory SubjectCategory { get; set; } = null!;

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
