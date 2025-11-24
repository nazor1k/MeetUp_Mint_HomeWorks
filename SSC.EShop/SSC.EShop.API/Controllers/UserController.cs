using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSC.Eshop.Business.DTOs;
using SSC.Eshop.Business.Services.UserService;
using SSC.EShop.Core.Entities;
using SSC.EShop.Core.Interfaces;

namespace SSC.EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAppLogger<UserController> _logger;
        public UserController(IUserService userService, IAppLogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetAllUsers", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetUserById", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var result = await _userService.RegisterAsync(createUserDto);
                if (result)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                return BadRequest("User registration failed");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Register", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var result = await _userService.UpdateAsync(id, updateUserDto);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in UpdateUser",ex );
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in DeleteUser",ex );
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


    }
}
