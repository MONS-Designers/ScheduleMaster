using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Note
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<ScheduleNote> ScheduleNotes { get; set; } = new List<ScheduleNote>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
