using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public int? BuildingNumber { get; set; }

        public char? Enterance { get; set; }

        public int? ZipCode { get; set; }
    }
}
