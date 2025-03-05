using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class SchoolManager
{
    public int Id { get; set; }

    public int ManagerId { get; set; }

    public int SchoolId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual Manager Manager { get; set; } = null!;

    public virtual ICollection<ManagerSchoolTeacher> ManagerSchoolTeachers { get; set; } = new List<ManagerSchoolTeacher>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual School School { get; set; } = null!;

    public virtual ICollection<TeacherEmployment> TeacherEmployments { get; set; } = new List<TeacherEmployment>();
}
