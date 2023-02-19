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

        /// <summary>
        /// Changes the user's name
        /// </summary>
        [HttpPost("name")]
        [Authorize]
        public async Task<IActionResult> ChangeUserName(string name)
        {
            await _userService.ChangeUserName(User, name);
            return Ok("User name changed successfully");
        }

        /// <summary>
        /// Changes the user's password
        /// </summary>
        [HttpPost("password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            await _userService.ChangePassword(User, currentPassword, newPassword);
            return Ok("Password changed successfully");
        }

        /// <summary>
        /// Changes the user's email
        /// </summary>
        [HttpPost("email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail(string currentPassword, string newEmail)
        {
            await _userService.ChangeEmail(User, currentPassword, newEmail);
            return Ok("Email changed successfully");
        }

        /// <summary>
        /// Changes the user's profile photo
        /// </summary>
        [HttpPost("photo")]
        [Authorize]
        public async Task<IActionResult> ChangeProfilePhoto(IFormFile? photo)
        {
            await _userService.ChangeProfilePhoto(User, photo);
            return Ok("Profile photo changed successfully");
        }

        /// <summary>
        /// Changes the user's bio
        /// </summary>
        [HttpPost("bio")]
        [Authorize]
        public async Task<IActionResult> ChangeBio([FromBody] string bio)
        {
            await _userService.ChangeBio(User, bio);
            return Ok("Bio changed successfully");
        }
    }
}