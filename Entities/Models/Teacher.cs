using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public DateOnly? SeniorityStartDate { get; set; }

    public int SchoolUserId { get; set; }

    public virtual ICollection<DiplomaTeacher> DiplomaTeachers { get; set; } = new List<DiplomaTeacher>();

    public virtual ICollection<ManagerTeacher> ManagerTeachers { get; set; } = new List<ManagerTeacher>();

    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; } = new List<ScheduleSubject>();

    public virtual SchoolUser SchoolUser { get; set; } = null!;

    public virtual ICollection<TeacherConcentraint> TeacherConcentraints { get; set; } = new List<TeacherConcentraint>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
