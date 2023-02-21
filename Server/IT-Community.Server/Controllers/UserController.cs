using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Interfaces;
using System.Collections.Generic;

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
        /// Gets information about the user
        /// </summary>
        [HttpGet("{username}")]
        public async Task<UserFullDto>? GetUser(string username)
        {
            return await _userService.GetUserInfo(username);
        }

        /// <summary>
        /// Gets created articles by a specific user
        /// </summary>
        [HttpGet("{username}/articles")]
        public async Task<List<PostPreviewDto>> GetUserArticles(string username)
        {
            return await _userService.GetUserArticles(username);
        }

        /// <summary>
        /// Changes the user's username
        /// </summary>
        [HttpPost("username")]
        [Authorize]
        public async Task<IActionResult> ChangeUserName(string name)
        {
            await _userService.ChangeUserName(User, name);
            return Ok("Username changed successfully");
        }

        /// <summary>
        /// Changes the user's full name
        /// </summary>
        [HttpPost("name")]
        [Authorize]
        public async Task<IActionResult> ChangeName(string name)
        {
            await _userService.ChangeName(User, name);
            return Ok("Name changed successfully");
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