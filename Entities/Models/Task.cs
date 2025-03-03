using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Task
{
    public int Id { get; set; }

    public int PriorityId { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public bool? IsComplete { get; set; }

    public string? Description { get; set; }

    public int NoteId { get; set; }

    public string Title { get; set; } = null!;

    public int UserId { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual ICollection<StudentSubjectTask> StudentSubjectTasks { get; set; } = new List<StudentSubjectTask>();

    public virtual User User { get; set; } = null!;
}
