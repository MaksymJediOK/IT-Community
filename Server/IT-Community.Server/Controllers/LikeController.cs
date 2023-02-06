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
        /// Toggle like/unlike on a specific post for a user
        /// </summary>
        /// <param name="postId">The id of the post</param>
        /// <param name="userId">The id of the user</param>
        [HttpPost("{postId}")]
        public async Task<IActionResult> ToggleLike(int postId, string userId)
        {
            await _likeService.ToggleLike(postId, userId);
            return Ok();
        }

        /// <summary>
        /// Get the list of posts liked by a specific user
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>The list of posts liked by the user</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLikedPosts(string userId)
        {
            var likedPosts = _likeService.GetLikedPosts(userId);
            return Ok(likedPosts);
        }
    }
}
