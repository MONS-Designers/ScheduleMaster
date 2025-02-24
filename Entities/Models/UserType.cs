﻿using System;
using System.Collections.Generic;

namespace Entities.Models;

/// <summary>
/// Code table
/// </summary>
public partial class UserType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
