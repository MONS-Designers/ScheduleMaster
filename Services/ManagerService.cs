using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;
using Repositories;

namespace Services
{
    public class ManagerService:IManagerService
    {
        private readonly IManagerRepository _repository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _repository = managerRepository;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Manager> UpdateAsync(int id, Manager manager)
        {
            return await _repository.UpdateAsync(id, manager);
        }
        public async Task<int> AddAsync(Manager manager)
        {
            return await _repository.AddAsync(manager);
        }
        public async Task<IEnumerable<TeacherDetailsDTO>> GetTeachersByParametersAsync(int id)
        {
            return await _repository.GetTeachersByParametersAsync(id);
        }
    }
}
