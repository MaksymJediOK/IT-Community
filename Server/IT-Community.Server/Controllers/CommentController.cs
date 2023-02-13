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

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Method returns list of comments for a cpecific post
        /// </summary>
        [HttpGet("{postId}")]
        public List<CommentPostDto> GetComments(int postId)
        {
            return _commentService.GetCommentsWithReplies(postId);
        }

        /// <summary>
        /// Method creates comment in DB
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CommentCreateDto comment)
        {
            var userId = GetUserId();
            await _commentService.CreateComment(comment, userId);
            return Ok();
        }

        /// <summary>
        /// Method updates comment in DB
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdatePost(CommentUpdateDto comment)
        {
            var userId = GetUserId();
            await _commentService.UpdateComment(comment, userId);
            return Ok();
        }

        /// <summary>
        /// Method deletes comment in DB
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            var userId = GetUserId();
            await _commentService.DeleteComment(id, userId);
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
