using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IT_Community.Server.Infrastructure.Interfaces;

namespace IT_Community.Server.Controllers
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

        /// <summary>
        /// Registers a new user
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            await _authService.Register(userRegisterDto);
            return Ok();
        }

        /// <summary>
        /// Logins an existing user and returns a JWT bearer token
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var token = await _authService.Login(userLoginDto);
            return Ok(token);
        }

        /// <summary>
        /// Checks if the user is authorized
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult CheckAuthorize()
        {
            return new JsonResult(new { IsAuthorized = true });
        }

        /// <summary>
        /// Logs out the currently logged in user
        /// </summary>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok();
        }
    }
}
