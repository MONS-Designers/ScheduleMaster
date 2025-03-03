using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int AddressId { get; set; }

    public byte[]? ProfileImage { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Secretary> Secretaries { get; set; } = new List<Secretary>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
