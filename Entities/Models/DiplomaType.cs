using System;
using System.Collections.Generic;

namespace Entities.Models;
/// <summary>
/// Code table
/// BeD, CV etc.
/// </summary>
public partial class DiplomaType
{
    public int Id { get; set; }

    public int Name { get; set; }

    public virtual ICollection<DiplomaTeacher> DiplomaTeachers { get; set; } = new List<DiplomaTeacher>();
}
