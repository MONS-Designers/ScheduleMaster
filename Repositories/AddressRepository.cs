using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ScheduleMasterContext _scheduleMasterContext;
        public AddressRepository(ScheduleMasterContext scheduleMasterContext)
        {
            _scheduleMasterContext = scheduleMasterContext;
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            IEnumerable<Address> addresses = await _scheduleMasterContext.Addresses.ToListAsync();
            return addresses;
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _scheduleMasterContext.Addresses.FindAsync(id);
        }

        public async Task<int> AddAsync(Address address)
        {
            await _scheduleMasterContext.Addresses.AddAsync(address);
            await _scheduleMasterContext.SaveChangesAsync();
            return address.Id;
        }

        public async Task<Address> UpdateAsync(int id, Address address)
        {
            address.Id = id;
            _scheduleMasterContext.Update(address);
            await _scheduleMasterContext.SaveChangesAsync();
            return address;
        }
    }
}
