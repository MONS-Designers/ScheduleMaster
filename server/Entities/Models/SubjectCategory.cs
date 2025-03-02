using System;
using System.Collections.Generic;

namespace Entities.Models;

/// <summary>
/// Code table
/// </summary>
public partial class SubjectCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SchoolGroup> SchoolGroups { get; set; } = new List<SchoolGroup>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
