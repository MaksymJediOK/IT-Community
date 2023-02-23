using IT_Community.Server.Infrastructure.Dtos.AnswerDTOs;
using IT_Community.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAnswerService _answerService;

        public AnswerController(IUserService userService, IAnswerService answerService)
        {
            _userService = userService;
            _answerService = answerService;
        }
        /// <summary>
        /// Returns all answers for specific vacancy
        /// </summary>
        [HttpGet("{vacancyId}")]
        [Authorize]
        public async Task<List<AnswerPreviewDto>> GetAnswerPreview(int vacancyId)
        {
            var userId = await _userService.GetUserId(User);
            var answers = _answerService.GetAnswerPreviews(vacancyId, userId);

            return answers;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAnswer([FromForm]AnswerCreateDto answerCreateDto)
        {
            var userId = await _userService.GetUserId(User);
            await _answerService.CreateAnswer(answerCreateDto, userId);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var userId = await _userService.GetUserId(User);
            await _answerService.DeleteAnswer(id, userId);
            return Ok();
        }
    }
}
