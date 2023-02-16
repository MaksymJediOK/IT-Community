using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        /// <summary>
        /// Toggles like/unlike on a specific post for a user
        /// </summary>
        /// <param name="postId">The ID of the post</param>
        [HttpPost("{postId}")]
        public async Task<IActionResult> ToggleLike(int postId, string userId)
        {
            await _likeService.ToggleLike(postId, userId);
            return Ok();
        }

        /// <summary>
        /// Gets the list of posts liked by a user
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLikedPosts(string userId)
        {
            var likedPosts = _likeService.GetLikedPosts(userId);
            return Ok(likedPosts);
        }
    }
}
