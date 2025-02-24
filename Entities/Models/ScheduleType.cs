using System;
using System.Collections.Generic;

namespace Entities.Models;

/// <summary>
/// Code table
/// </summary>
public partial class ScheduleType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
