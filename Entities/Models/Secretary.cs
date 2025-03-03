using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Secretary
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<SchoolSecretary> SchoolSecretaries { get; set; } = new List<SchoolSecretary>();

    public virtual User User { get; set; } = null!;
}
