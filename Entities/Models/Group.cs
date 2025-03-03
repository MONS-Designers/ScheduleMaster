using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SchoolManagerId { get; set; }

    public int SubjectCategoryId { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual SchoolManager SchoolManager { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual SubjectCategory SubjectCategory { get; set; } = null!;
}
