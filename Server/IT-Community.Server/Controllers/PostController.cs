using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IT_Community.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostsService _postService;

        public PostController(IPostsService _postService)
        {
            this._postService = _postService;
        }

        /// <summary>
        /// Method returns list with elements from Posts table to fill preview articles page
        /// </summary>
        [HttpGet]
        public List<PostPreviewDto> GetPreviewPosts()
        {
            return _postService.GetPostPreview();
        }

        /// <summary>
        /// Get a list of popular posts based on the specified time period
        /// </summary>
        /// <param name="timePeriod">The time period for which to retrieve popular posts. Acceptable values are "month", "year", and "all time".</param>
        /// <returns>A list of popular posts based on the specified time period.</returns>
        [HttpGet("popular/{timePeriod=all time}")]
        public List<PostPreviewDto> GetPopularPosts(string timePeriod = "all time")
        {
            return _postService.GetPopularPosts(timePeriod.Trim());
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<PostFullDto>? GetPost(int id)
        {
            return await _postService.GetPost(id);
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreatePost([FromForm] PostCreateDto postCteateDto)
        {
            //string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //if (userId == null)
            //{
            //    return BadRequest("Немає залогіненого юзера");
            //}
            string userId = "1";
            await _postService.CreatePost(postCteateDto, userId);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(int id, [FromForm] PostCreateDto postCteateDto)
        {
            string userId = "1";
            await _postService.EditPost(postCteateDto, userId, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_postService.IsExist(id))
            {
                await _postService.DeletePost(id);
            } 
            else
            {
                return NotFound();
            }
            
            return Ok();
        }
    }
}
