
using SSC.Eshop.Business.DTOs;
using SSC.EShop.Core.Entities;
using SSC.EShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SSC.Eshop.Business.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UserService> _eshopLogger;
        public UserService(IUserRepository userRepository, IAppLogger<UserService> eshopLogger, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _eshopLogger = eshopLogger;
            _unitOfWork = unitOfWork;

        }


        public async Task<bool> RegisterAsync(CreateUserDto createUserDto)
        {
            var existingUsers = await _userRepository.GetByConditionAsync(u => u.Login == createUserDto.Login);
            if (existingUsers.Any())
            {
                _eshopLogger.LogWarning($"Register failed. User with login {createUserDto.Login} already exists.");
                return false;
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Login = createUserDto.Login,
                FirstName = createUserDto.FirstName,
                Password = createUserDto.Password
            };

            await _userRepository.InsertAsync(newUser);
            await _unitOfWork.SaveChangesAsync();

            _eshopLogger.LogInfo($"User {newUser.Id} registered successfully.");
            return true;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName ?? string.Empty
            }).ToList();
        }

       

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                _eshopLogger.LogWarning($"User with id {id} not found.");
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName ?? string.Empty
            };
        }
        public async Task<bool> InsertAsync(User user)
        {
            try
            {
                await _userRepository.InsertAsync(user);
                await _unitOfWork.SaveChangesAsync();
                _eshopLogger.LogInfo("User inserted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _eshopLogger.LogError("Error in InsertUserAsync", ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                _eshopLogger.LogWarning($"Update failed. User with id {id} not found.");
                return false;
            }

            user.FirstName = updateUserDto.FirstName;
            user.Login = updateUserDto.Login;

            await _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            _eshopLogger.LogInfo($"User {id} updated successfully.");
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                _eshopLogger.LogWarning($"Delete failed. User with id {id} not found.");
                return false;
            }

            await _userRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            _eshopLogger.LogInfo($"User {id} deleted successfully.");
            return true;
        }
    }
}
