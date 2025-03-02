using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class ScheduleNote
{
    public int Id { get; set; }

    public int NoteId { get; set; }

    public int ScheduleId { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;
}
