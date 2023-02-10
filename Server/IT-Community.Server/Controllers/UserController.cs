using Microsoft.AspNetCore.Mvc;
using IT_Community.Server.Infrastructure.Services;

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
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            var userId = await _userService.GetUserId(User);
            await _userService.ChangePassword(userId, currentPassword, newPassword);
            return Ok("Password changed successfully");
        }
    }
}