using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
