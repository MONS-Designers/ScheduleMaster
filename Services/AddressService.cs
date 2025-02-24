using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories;
using Task = System.Threading.Tasks.Task;

namespace Services
{
    public class AddressService : IAddressService
    {
        IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(Address address)
        {
            return await _addressRepository.AddAsync(address);
        }

        public async Task<Address> UpdateAsync(int id, Address address)
        {
            return await _addressRepository.UpdateAsync(id, address);
        }
    }
}
