using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagsService _tagService;

        public TagController(ITagsService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Returns the list of existing tags
        /// </summary>
        [HttpGet]
        public List<TagDto> GetPreviewTags()
        {
            return _tagService.GetTags();
        }

        /// <summary>
        /// Batch creates tags from a list of tags separated by commas
        /// </summary>
        /// <example>["tag1", "tag2", "tag3"]</example>
        [HttpPost]
        public async Task<IActionResult> BatchCreateTags([FromBody] List<string> tagNames)
        {
            await _tagService.BatchCreateTags(tagNames);
            return Ok();
        }

        /// <summary>
        /// Deletes tag from the database
        /// </summary>
        /// <remarks>If the post is associated with any tags, those tags will be removed from the post</remarks>
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTag(id);
            return Ok();
        }
    }
}
