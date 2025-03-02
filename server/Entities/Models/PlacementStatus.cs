using System;
using System.Collections.Generic;

namespace Entities.Models;

/// <summary>
/// Code table
/// </summary>
public partial class PlacementStatus
{
    public int Id { get; set; }

    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; } = new List<ScheduleSubject>();
}
