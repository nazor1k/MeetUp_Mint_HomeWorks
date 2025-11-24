using SSC.EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Eshop.Business.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> InsertAsync(User user);

        public Task<List<User>> GetAllAsync();
        public Task<User?> GetByIdAsync(Guid id);
        public Task<List<User>> GetByConditionAsync(Expression<Func<User, bool>> condition);


        public Task<bool> UpdateAsync(User user);

        public Task<bool> DeleteAsync(Guid id);
    }
}
