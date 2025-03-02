using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class Secretary
{
    public int Id { get; set; }

    public int SchoolUserId { get; set; }

    public virtual SchoolUser SchoolUser { get; set; } = null!;
}
