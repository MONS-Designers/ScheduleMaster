using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class SchoolGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SchoolGroupId { get; set; }

    public int SchoolId { get; set; }

    public int SubjectCategoryId { get; set; }

    public virtual ICollection<SchoolGroup> InverseSchoolGroupNavigation { get; set; } = new List<SchoolGroup>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual School School { get; set; } = null!;

    public virtual SchoolGroup SchoolGroupNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual SubjectCategory SubjectCategory { get; set; } = null!;
}
