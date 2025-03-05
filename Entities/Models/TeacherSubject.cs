using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TeacherSubject
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public bool IsActive { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ICollection<TeacherEmployment> TeacherEmployments { get; set; } = new List<TeacherEmployment>();
}
