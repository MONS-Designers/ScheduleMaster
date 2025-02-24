using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class ManagerTeacher
{
    public int Id { get; set; }

    public int ManagerId { get; set; }

    public int TeacherId { get; set; }

    public virtual Manager Manager { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
