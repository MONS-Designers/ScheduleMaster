using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class SchoolUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SchoolId { get; set; }

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual School School { get; set; } = null!;

    public virtual ICollection<Secretary> Secretaries { get; set; } = new List<Secretary>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public virtual User User { get; set; } = null!;
}
