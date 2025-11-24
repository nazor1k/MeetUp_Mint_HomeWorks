using Microsoft.EntityFrameworkCore;
using SSC.EShop.Core.Entities;
using SSC.EShop.Core.Interfaces;
using SSC.EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.EShop.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EshopDbContext _context;
        private readonly IAppLogger<UserRepository> _logger;

        public UserRepository(EshopDbContext context, IAppLogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<List<User>> GetByConditionAsync(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.Where(condition).AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }


        public async Task UpdateAsync(User user)
        {

            _context.Users.Update(user);


        }

    }
}
