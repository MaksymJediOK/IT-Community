using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public async Task<PostFullDto>? GetPost(int id)
        {
            if (_postService.IsExist(id))
                return await _postService.GetPost(id);
            else return null;
        }

        [HttpPost]
        //[Authorize]
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
