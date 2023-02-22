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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAnswer([FromForm]AnswerCreateDto answerCreateDto)
        {
            var userId = await _userService.GetUserId(User);
            await _answerService.CreateAnswer(answerCreateDto, userId);

            return Ok();
        }
    }
}
