using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TeacherConcentraint
{
    public int Id { get; set; }

    public bool? IsAble { get; set; }

    public bool? IsRequired { get; set; }

    public int DayOfWeek { get; set; }

    public TimeOnly? StartHour { get; set; }

    public TimeOnly? EndHour { get; set; }

    public int TeacherId { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
