using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Manager
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<SchoolManager> SchoolManagers { get; set; } = new List<SchoolManager>();

    public virtual SchoolManager User { get; set; } = null!;
}
