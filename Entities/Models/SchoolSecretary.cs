using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class SchoolSecretary
{
    public int Id { get; set; }

    public int SchoolId { get; set; }

    public int SecretaryId { get; set; }

    public virtual School School { get; set; } = null!;

    public virtual Secretary Secretary { get; set; } = null!;
}
