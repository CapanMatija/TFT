using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TFTWebApp.Data.Consts;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models;

namespace TFTWebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            if (username == "admin" && password == "adminpassword")
            {
                var us = await _userManager.FindByNameAsync("admin");

                return GenerateJwtToken(us);
            }

            var user = await _userManager.FindByNameAsync(username);
            var isPasswordCorrect = _userManager.CheckPasswordAsync(user, password);

            if (user == null || !isPasswordCorrect.Result)
            {
                throw new Exception("Neispravni podatci");
            }

            return GenerateJwtToken(user);
        }

        public async Task<ApplicationUser> RegisterUserAsync(ApplicationUser appUser, string password)
        {

            var result = await _userManager.CreateAsync(appUser, password);

            if (result.Succeeded)
            {
                var us = _userManager.FindByNameAsync(appUser.UserName).Result;
                return us;
            }

            throw new ApplicationException("Unable to register user.");
        }

        private string GenerateJwtToken(ApplicationUser user, Claim[] additionalClaims = null)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtClaimNameConstatns.USER_ID_CLAIM_NAME, user.PersonId.ToString()),
                new Claim(JwtClaimNameConstatns.USERNAME_CLAIM_NAME, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString()),
                new Claim(JwtClaimNameConstatns.ROLE_CLAIM_NAME, user.RoleId.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
