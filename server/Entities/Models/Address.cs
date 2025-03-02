using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? BuildingNumber { get; set; }

    public char? Enterance { get; set; }

    public int? ZipCode { get; set; }

    public virtual ICollection<School> Schools { get; set; } = new List<School>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
