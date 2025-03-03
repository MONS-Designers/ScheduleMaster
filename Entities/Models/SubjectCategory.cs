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

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
