using System;
using System.Collections.Generic;

namespace Entities.Models;

/// <summary>
/// Code table
/// נוכחות מלאה, חלקית, חסר
/// </summary>
public partial class Presence
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudentSubjectAssessment> StudentSubjectAssessments { get; set; } = new List<StudentSubjectAssessment>();
}
