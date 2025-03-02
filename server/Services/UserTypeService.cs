using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories;

namespace Services
{
    public class UserTypeService:IUserTypeService
    {
        private readonly IUserTypeRepository _repository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _repository = userTypeRepository;
        }

        public async Task<IEnumerable<UserType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<UserType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<UserType> UpdateAsync(int id, UserType userType)
        {
            return await _repository.UpdateAsync(id, userType);
        }
        public async Task<int> AddAsync(UserType userType)
        {
            return await _repository.AddAsync(userType);
        }
    }
}
