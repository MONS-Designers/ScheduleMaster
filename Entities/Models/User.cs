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

    public int UserTypeId { get; set; }

    public byte[]? ProfileImage { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<SchoolUser> SchoolUsers { get; set; } = new List<SchoolUser>();

    public virtual UserType UserType { get; set; } = null!;
}
