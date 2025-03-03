using System;
using System.Collections.Generic;

namespace Entities.Models;

/// <summary>
/// Code table
/// שכר מרצים, תקן וכו&apos;
/// </summary>
public partial class EmploymentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TeacherEmployment> TeacherEmployments { get; set; } = new List<TeacherEmployment>();
}
