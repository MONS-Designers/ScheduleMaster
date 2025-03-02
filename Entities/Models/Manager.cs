using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class Manager
{
    public int Id { get; set; }

    public int SchoolUserId { get; set; }

    public virtual ICollection<ManagerTeacher> ManagerTeachers { get; set; } = new List<ManagerTeacher>();

    public virtual SchoolUser SchoolUser { get; set; } = null!;
}
