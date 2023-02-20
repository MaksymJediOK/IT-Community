using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Claims;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        /// <summary>
        /// Returns the list of comments for a specific post
        /// </summary>
        [HttpGet("{postId}")]
        public List<CommentPostDto> GetComments(int postId)
        {
            return _commentService.GetCommentsWithReplies(postId);
        }

        /// <summary>
        /// Creates a new comment on a post
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CommentCreateDto comment)
        {
            var userId = await _userService.GetUserId(User);
            await _commentService.CreateComment(comment, userId);
            return Ok();
        }

        /// <summary>
        /// Updates an existing comment on a post
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdatePost(CommentUpdateDto comment)
        {
            var userId = await _userService.GetUserId(User);
            await _commentService.UpdateComment(comment, userId);
            return Ok();
        }

        /// <summary>
        /// Deletes an existing comment on a post
        /// </summary>
        /// <param name="id">ID of the comment to delete</param>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            var userId = await _userService.GetUserId(User);
            await _commentService.DeleteComment(id, userId);
            return Ok();
        }
    }
}
