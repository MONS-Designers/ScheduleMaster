using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DiplomaTeacher
{
    public int Id { get; set; }

    public byte[]? Image { get; set; }

    public int DiplomaTypeId { get; set; }

    public int TeacherId { get; set; }

    public virtual DiplomaType DiplomaType { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
