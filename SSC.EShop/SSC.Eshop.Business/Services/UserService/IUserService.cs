using SSC.Eshop.Business.DTOs;
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
        public Task<bool> RegisterAsync(CreateUserDto createUserDto );

        public Task<List<UserDto>> GetAllAsync();
        public Task<UserDto?> GetByIdAsync(Guid id);
       


        public Task<bool> UpdateAsync(Guid id, UpdateUserDto updateUserDto);

        public Task<bool> DeleteAsync(Guid id);
    }
}
