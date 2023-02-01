using IT_Community.Server.Core;
using IT_Community.Server.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly DataContext _context;

        public LikeController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint for toggling like/unlike on a specific post for a user
        /// </summary>
        /// <param name="postId">The id of the post</param>
        /// <param name="userId">The id of the user</param>
        [HttpPost("{postId}")]
        public async Task<ActionResult<Like>> ToggleLike(int postId, string userId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return NotFound();
            }

            var like = await _context.Likes
                .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
            if (like == null)
            {
                like = new Like
                {
                    PostId = postId,
                    UserId = userId
                };
                _context.Likes.Add(like);
            }
            else
            {
                _context.Likes.Remove(like);
            }
            await _context.SaveChangesAsync();

            return like;
        }

        /// <summary>
        /// Endpoint for retrieving the list of posts liked by a specific user
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>The list of posts liked by the user</returns>
        [HttpGet("user/{userId}")]
        public IActionResult GetLikedPosts(string userId)
        {
            var likedPosts = _context.Likes
                .Where(l => l.UserId == userId)
                .Select(l => l.Post)
                .ToList();

            return Ok(likedPosts);
        }
    }
}
