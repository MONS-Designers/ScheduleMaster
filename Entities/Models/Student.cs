using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Student
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public int SchoolGroupId { get; set; }

    public int SchoolUserId { get; set; }

    public virtual SchoolGroup SchoolGroup { get; set; } = null!;

    public virtual SchoolUser SchoolUser { get; set; } = null!;

    public virtual ICollection<StudentSubjectAssessment> StudentSubjectAssessments { get; set; } = new List<StudentSubjectAssessment>();

    public virtual ICollection<StudentSubjectTask> StudentSubjectTasks { get; set; } = new List<StudentSubjectTask>();
}
