using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Task = System.Threading.Tasks.Task;

namespace Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task<int> AddAsync(Address address);
        Task<Address> UpdateAsync(int id, Address address);
    }
}
