using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Data.Enums;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AuthenticatedController

    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IHttpContextAccessor contextAccessor) :base (contextAccessor) 
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDTO)
        {
            if (_jwtUserRole != ApplicationRoleEnum.SuperAdministrator)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.CreateUserAsync(userDTO);
            return Ok(createdUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            if (_jwtUserRole != ApplicationRoleEnum.SuperAdministrator)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            if (_jwtUserRole != ApplicationRoleEnum.SuperAdministrator)
            {
                return BadRequest();
            }
            var users = await _userService.GetUsers();

            return Ok(users);
        }
    }
}
