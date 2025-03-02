using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Task
{
    public int Id { get; set; }

    public int TaskPriorityId { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public bool? IsComplete { get; set; }

    public string? Description { get; set; }

    public int NoteId { get; set; }

    public string Title { get; set; } = null!;

    public int SchoolUserId { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual SchoolUser SchoolUser { get; set; } = null!;

    public virtual ICollection<StudentSubjectTask> StudentSubjectTasks { get; set; } = new List<StudentSubjectTask>();

    public virtual TaskPriority TaskPriority { get; set; } = null!;
}
