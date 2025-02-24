using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UserTypeRepository:IUserTypeRepository
    {
        private readonly ScheduleMasterContext _context;

        public UserTypeRepository(ScheduleMasterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserType>> GetAllAsync()
        {
            return _context.UserTypes.ToList();
        }
        public async Task<UserType> GetByIdAsync(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }
        public async Task<UserType> UpdateAsync(int id, UserType userType)
        {
            userType.Id = id;
            _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
            return userType;
        }
        public async Task<int> AddAsync(UserType userType)
        {
            await _context.UserTypes.AddAsync(userType);
            await _context.SaveChangesAsync();
            return userType.Id;
        }
    }
}
