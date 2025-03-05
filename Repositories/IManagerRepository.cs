using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> GetByIdAsync(int id);
        Task<Manager> UpdateAsync(int id, Manager manager);
        Task<int> AddAsync(Manager manager);
        Task<IEnumerable<TeacherDetailsDTO>> GetTeachersByParametersAsync(int id);
    }
}
