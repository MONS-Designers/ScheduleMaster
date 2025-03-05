using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.DTOs
{
    public class TeacherDetailsDTO
    {
        public required int teacherId {  get; set; }
        public required string Mail { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Telephone { get; set; }

        public string? CellPhone { get; set; }

        public string? ProfileImageURL { get; set; }

        public string? ProfileName { get; set; }

        public IEnumerable<SubjectDTO>? Subjects { get; set; }
    }
}
