using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class Schedule
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? DestinationDate { get; set; }

    public int SchoolGroupId { get; set; }

    public int ScheduleTypeId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ScheduleNote> ScheduleNotes { get; set; } = new List<ScheduleNote>();

    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; } = new List<ScheduleSubject>();

    public virtual ScheduleType ScheduleType { get; set; } = null!;

    public virtual SchoolGroup SchoolGroup { get; set; } = null!;
}
