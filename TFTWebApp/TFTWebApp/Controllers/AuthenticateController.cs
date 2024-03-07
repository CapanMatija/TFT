using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Data.Consts;
using TFTWebApp.Data.Enums;

namespace TFTWebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenticatedController : ControllerBase
    {
        protected ApplicationRoleEnum _jwtUserRole { get { return jwtUserRole; } private set { } }
        protected string _jwtUsername { get { return jwtUsername; } private set { } }
        protected long _jwtUserId { get { return jwtUserId; } private set { } }


        private ApplicationRoleEnum jwtUserRole;
        private string jwtUsername;
        private long jwtUserId;

        public AuthenticatedController( IHttpContextAccessor contextAccessor)
        {
            LogRequest(contextAccessor);
            ReadJWTData(contextAccessor);
        }

        private void LogRequest(IHttpContextAccessor contextAccessor)
        {
            
        }
        private void ReadJWTData(IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor.HttpContext.User != null)
            {
                var role = contextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == JwtClaimNameConstatns.ROLE_CLAIM_NAME);
                var username = contextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == JwtClaimNameConstatns.USERNAME_CLAIM_NAME);
                var userId = contextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == JwtClaimNameConstatns.USER_ID_CLAIM_NAME);

                if (role != null)
                {
                    Enum.TryParse(role.Value, out jwtUserRole);
                }

                if (username != null)
                {
                    jwtUsername = username.Value;
                }

                if (userId != null)
                {
                    jwtUserId = Convert.ToInt64(userId.Value);
                }

            }
        }

    }
}
