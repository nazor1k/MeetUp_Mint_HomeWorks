using SSC.EShop.Core.Entities;
using SSC.EShop.Core.Interfaces;
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
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<UserRepository> _logger;
        
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetByConditionAsync(Expression<Func<User, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
