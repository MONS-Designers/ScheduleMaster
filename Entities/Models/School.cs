using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class School
{
    public int Id { get; set; }

    public string InstitutionSymbol { get; set; } = null!;

    public string? Name { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<SchoolManager> SchoolManagers { get; set; } = new List<SchoolManager>();

    public virtual ICollection<SchoolSecretary> SchoolSecretaries { get; set; } = new List<SchoolSecretary>();
}
