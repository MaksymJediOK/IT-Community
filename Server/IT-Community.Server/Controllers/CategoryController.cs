using IT_Community.Server.Infrastructure.Dtos.CategoryDTOs;
using IT_Community.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Returns the list of existing categories
        /// </summary>
        [HttpGet]
        public List<CategoryDto> GetPreviewCategories()
        {
            return _categoryService.GetCategories();
        }

        /// <summary>
        /// Batch creates ctegories from a list of categories separated by commas
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> BatchCreateCategories([FromBody] List<string> tagNames)
        {
            await _categoryService.BatchCreateCategories(tagNames);
            return Ok();
        }

        /// <summary>
        /// Deletes category from the database
        /// </summary>
        /// <remarks>If the post is associated with any tags, those tags will be removed from the post</remarks>
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
