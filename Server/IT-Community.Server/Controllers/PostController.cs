using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
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

        [HttpGet("parameters")]
        public List<PostPreviewDto> GetPreviewPostsWithFilter([FromQuery] List<int>? tagIds, string? dateFilter, string? orderBy)
        {
            return _postService.GetSortedFilteredPostPreview(orderBy, dateFilter, tagIds);
        }

        [HttpGet("{id}")]
        public async Task<PostFullDto>? GetPost(int id)
        {
            return await _postService.GetPost(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromForm] PostCreateDto postCteateDto)
        {
            var userId = GetUserId();
            await _postService.CreatePost(postCteateDto, userId);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditPost(int id, [FromForm] PostCreateDto postCteateDto)
        {
            string userId = GetUserId();
            await _postService.EditPost(postCteateDto, userId, id);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            string userId = GetUserId();

            await _postService.DeletePost(id, userId);

            return Ok();
        }

        [NonAction]
        public string GetUserId()
        {
            string userId = "";
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            }
            if (userId.IsNullOrEmpty())
            {
                throw new HttpException("User id null", HttpStatusCode.BadRequest);
            }
            return userId;
        }
    }
}
