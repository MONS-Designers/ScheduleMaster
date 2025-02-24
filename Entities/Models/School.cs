using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class School
{
    public int Id { get; set; }

    public string InstitutionSymbol { get; set; } = null!;

    public string? Address { get; set; }

    public string? Name { get; set; }

    public int AddressId { get; set; }

    public virtual Address AddressNavigation { get; set; } = null!;

    public virtual ICollection<SchoolGroup> SchoolGroups { get; set; } = new List<SchoolGroup>();

    public virtual ICollection<SchoolUser> SchoolUsers { get; set; } = new List<SchoolUser>();
}
