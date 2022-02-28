using AuthService.Models;
using AuthService.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public AuthController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }

        [HttpPost("api/admin/login")]
        public IActionResult AdminLogin(User user)
        {
            return Ok(authManager.AuthenticateAdmin(user));
        }

        [HttpPost("api/user/login")]
        public IActionResult UserLogin(User user)
        {
            return Ok(authManager.AuthenticateUser(user));
        }

        [HttpPost("api/user/register")]
        public IActionResult UserRegister(User user)
        {
            authManager.UserRegister(user);
            return Ok();
        }
    }
}
