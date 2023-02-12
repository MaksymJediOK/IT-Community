using Microsoft.AspNetCore.Mvc;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            string userId = await _userService.GetUserId(User);
            await _userService.ChangePassword(userId, currentPassword, newPassword);
            return Ok("Password changed successfully");
        }

        [HttpPost("change-email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail(string currentPassword, string newEmail)
        {
            string userId = await _userService.GetUserId(User);
            await _userService.ChangeEmail(userId, currentPassword, newEmail);
            return Ok("Email changed successfully");
        }
    }
}