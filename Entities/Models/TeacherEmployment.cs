using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TeacherEmployment
{
    public int Id { get; set; }

    public int EmploymentTypeId { get; set; }

    public int SumPerHour { get; set; }

    public int SchoolManagerId { get; set; }

    public int TeacherSubjectId { get; set; }

    public bool IsActive { get; set; }

    public virtual EmploymentType EmploymentType { get; set; } = null!;

    public virtual SchoolManager SchoolManager { get; set; } = null!;

    public virtual TeacherSubject TeacherSubject { get; set; } = null!;
}
