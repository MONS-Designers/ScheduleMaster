using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public DateOnly? SeniorityStartDate { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<DiplomaTeacher> DiplomaTeachers { get; set; } = new List<DiplomaTeacher>();

    public virtual ICollection<ManagerSchoolTeacher> ManagerSchoolTeachers { get; set; } = new List<ManagerSchoolTeacher>();

    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; } = new List<ScheduleSubject>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    public virtual User User { get; set; } = null!;
}
