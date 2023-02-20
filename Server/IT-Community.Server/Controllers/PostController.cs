using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostsService _postService;
        private readonly IUserService _userService;

        public PostController(IPostsService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        /// <summary>
        /// Returns the list with elements from Posts table to fill preview articles page
        /// </summary>
        [HttpGet]
        public List<PostPreviewDto> GetPreviewPosts()
        {

            return _postService.GetPostPreview();
        }

        /// <summary>
        /// Returns a list of posts filtered based on the provided parameters
        /// </summary>
        /// <param name="tagIds">The list of tag IDs to filter the posts by</param>
        /// <param name="searchString">The string to search for in the post title</param>
        /// <param name="dateFilter">The filter to apply to the post date. Valid values are "Today", "Week", "Months" and "Year"</param>
        /// <param name="orderBy">The field to sort the posts by. Valid values are "Popularity", "NewOnTop" and "OldOnTop"</param>
        [HttpGet("parameters")]
        public List<PostPreviewDto> GetPreviewPostsWithFilter([FromQuery] List<int>? tagIds, string? searchString, string? dateFilter, string? orderBy)
        {
            return _postService.GetSortedFilteredPostPreview(searchString, orderBy, dateFilter, tagIds);
        }

        /// <summary>
        /// Gets full post by ID
        /// </summary>
        /// <param name="id">Post ID</param>
        [HttpGet("{id}")]
        public async Task<PostFullDto>? GetPost(int id)
        {
            return await _postService.GetPost(id);
        }

        /// <summary>
        /// Creates a new post
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromForm] PostCreateDto postCteateDto)
        {
            var userId = await _userService.GetUserId(User);
            await _postService.CreatePost(postCteateDto, userId);
            return Ok();
        }

        /// <summary>
        /// Edits a post by ID
        /// </summary>
        /// <param name="id">The ID of the post to edit</param>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditPost(int id, [FromForm] PostCreateDto postCteateDto)
        {
            var userId = await _userService.GetUserId(User);
            await _postService.EditPost(postCteateDto, userId, id);
            return Ok();
        }

        /// <summary>
        /// Deletes a post by ID
        /// </summary>
        /// <param name="id">The ID of the post to delete</param>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            var userId = await _userService.GetUserId(User);

            await _postService.DeletePost(id, userId);

            return Ok();
        }
    }
}
