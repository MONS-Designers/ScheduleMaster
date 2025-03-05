using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ManagerSchoolTeacher
{
    public int Id { get; set; }

    public int SchoolManagerId { get; set; }

    public int TeacherId { get; set; }

    public bool IsActive { get; set; }

    public virtual SchoolManager SchoolManager { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ICollection<TeacherConcentraint> TeacherConcentraints { get; set; } = new List<TeacherConcentraint>();
}
