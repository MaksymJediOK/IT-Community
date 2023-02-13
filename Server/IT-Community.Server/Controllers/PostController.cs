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
        private readonly IUserService _userService;

        public PostController(IPostsService _postService, IUserService userService)
        {
            this._postService = _postService;
            _userService = userService;
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
        public List<PostPreviewDto> GetPreviewPostsWithFilter([FromQuery] List<int>? tagIds, string? searchString, string? dateFilter, string? orderBy)
        {
            return _postService.GetSortedFilteredPostPreview(searchString, orderBy, dateFilter, tagIds);
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
            var userId = await _userService.GetUserId(User);
            await _postService.CreatePost(postCteateDto, userId);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditPost(int id, [FromForm] PostCreateDto postCteateDto)
        {
            var userId = await _userService.GetUserId(User);
            await _postService.EditPost(postCteateDto, userId, id);
            return Ok();
        }

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
