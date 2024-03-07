using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials credentials)
        {
            var token = await _authService.AuthenticateAsync(credentials.Username, credentials.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserDTO model)
        {

            return Ok();
        }
    }
}
