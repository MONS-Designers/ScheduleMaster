using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Repositories
{
    public class AddressRepositoryBase
    {
        private readonly ScheduleMasterContext _scheduleMasterContext;

        public async Task<int> AddAsync(Address address)
        {
            await _scheduleMasterContext.Addresses.AddAsync(address);
            await _scheduleMasterContext.SaveChangesAsync();
            return address.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _scheduleMasterContext.Addresses.FindAsync(id);
            if (address != null)
            {
                _scheduleMasterContext.Remove(address);
                await _scheduleMasterContext.SaveChangesAsync();
            }
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

        public async Task<Address> UpdateAsync(int id, Address address)
        {
            address.Id = id;
            _scheduleMasterContext.Update(address);
            await _scheduleMasterContext.SaveChangesAsync();
            return address;
        }
    }
}