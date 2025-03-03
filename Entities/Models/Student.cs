using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Student
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public int GroupId { get; set; }

    public int UserId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<StudentSubjectAssessment> StudentSubjectAssessments { get; set; } = new List<StudentSubjectAssessment>();

    public virtual ICollection<StudentSubjectTask> StudentSubjectTasks { get; set; } = new List<StudentSubjectTask>();

    public virtual User User { get; set; } = null!;
}
