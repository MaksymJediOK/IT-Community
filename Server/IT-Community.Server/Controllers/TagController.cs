﻿using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
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
        /// Return list of tags
        /// </summary>
        [HttpGet]
        public List<TagDto> GetPreviewTags()
        {
            return _tagService.GetTags();
        }

        /// <summary>
        /// Batch create tags from a list of tag names
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> BatchCreateTags([FromBody] List<string> tagNames)
        {
            await _tagService.BatchCreateTags(tagNames);
            return Ok();
        }

        /// <summary>
        /// Delete tag from the database
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTag(id);
            return Ok();
        }
    }
}