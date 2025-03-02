using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllAsync();
        Task<UserType> GetByIdAsync(int id);
        Task<UserType> UpdateAsync(int id, UserType userType);
        Task<int> AddAsync(UserType userType);
    }
}
