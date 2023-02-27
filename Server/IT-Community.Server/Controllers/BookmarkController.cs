using IT_Community.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly IUserService _userService;

        public BookmarkController(IBookmarkService bookmarkService, IUserService userService)
        {
            _bookmarkService = bookmarkService;
            _userService = userService;
        }

        /// <summary>
        /// Toggles bookmark on a specific post for a user
        /// </summary>
        /// <param name="postId">The ID of the post</param>
        [HttpPost("{postId}")]
        [Authorize]
        public async Task<IActionResult> ToggleBookmark(int postId)
        {
            var userId = await _userService.GetUserId(User);
            await _bookmarkService.ToggleBookmark(postId, userId);
            return Ok();
        }

        /// <summary>
        /// Gets the list of posts bookmarked by a user
        /// </summary>
        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetBookmarkedPosts()
        {
            var userId = await _userService.GetUserId(User);
            var bookmarkedPosts = _bookmarkService.GetBookmarkedPosts(userId);
            return Ok(bookmarkedPosts);
        }

        /// <summary>
        /// Checks if the post is bookmarked
        /// </summary>
        [HttpGet("user/{postId}")]
        [Authorize]
        public async Task<IActionResult> IsBookmarked(int postId)
        {
            var userId = await _userService.GetUserId(User);
            return await _bookmarkService.IsBookmarked(postId, userId);
        }
    }
}