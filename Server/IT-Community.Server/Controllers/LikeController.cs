using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly IUserService _userService;

        public LikeController(ILikeService likeService, IUserService userService)
        {
            _likeService = likeService;
            _userService = userService;
        }

        /// <summary>
        /// Toggle like/unlike on a specific post for a user
        /// </summary>
        /// <param name="postId">The id of the post</param>
        [HttpPost("{postId}")]
        [Authorize]
        public async Task<IActionResult> ToggleLike(int postId)
        {
            var userId = await _userService.GetUserId(User);
            await _likeService.ToggleLike(postId, userId);
            return Ok();
        }

        /// <summary>
        /// Get the list of posts liked by a specific user
        /// </summary>
        /// <returns>The list of posts liked by the user</returns>
        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetLikedPosts()
        {
            var userId = await _userService.GetUserId(User);
            var likedPosts = _likeService.GetLikedPosts(userId);
            return Ok(likedPosts);
        }
    }
}
