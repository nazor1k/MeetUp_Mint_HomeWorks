
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


        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    _eshopLogger.LogWarning($"User with id {id} not found.");
                    return false;
                }

                await _userRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                _eshopLogger.LogInfo($"User with id {id} deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _eshopLogger.LogError($"Error in DeleteUserAsync", ex);
                return false;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();

                if (users == null || users.Count == 0)
                {
                    _eshopLogger.LogWarning("No users found.");
                    return new List<User>();
                }

                _eshopLogger.LogInfo("Users retrieved successfully.");
                return users;
            }
            catch (Exception ex)
            {
                _eshopLogger.LogError("Error in GetAllUsersAsync", ex);
                return new List<User>();
            }
        }

        public async Task<List<User>> GetByConditionAsync(Expression<Func<User, bool>> condition)
        {
            try
            {
                var users = await _userRepository.GetByConditionAsync(condition);
                if (users == null || users.Count == 0)
                {
                    _eshopLogger.LogWarning("No users found matching the condition.");
                    return new List<User>();
                }

                return users;
            }
            catch (Exception ex)
            {
                _eshopLogger.LogError("Error in GetByConditionAsync", ex);
                return new List<User>();
            }
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            try
            {
                _eshopLogger.LogInfo($"Retrieving user with id {id}.");
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    _eshopLogger.LogWarning($"User with id {id} not found.");
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                _eshopLogger.LogError("Error in GetByIdAsync", ex);
                return null;
            }
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

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                var existingUser = await _userRepository.GetByIdAsync(user.Id);
                if (existingUser == null)
                {
                    _eshopLogger.LogWarning($"User with id {user.Id} not found.");
                    return false;
                }

                await _userRepository.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();

                _eshopLogger.LogInfo("User updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _eshopLogger.LogError("Error in UpdateUserAsync", ex);
                return false;
            }
        }
    }
}
