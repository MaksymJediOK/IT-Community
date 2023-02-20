using IT_Community.Server.Infrastructure.Dtos.VacancyDTOs;
using IT_Community.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IVacancyService _vacancyService;

        public VacancyController(IUserService userService, IVacancyService vacancyService)
        {
            _userService = userService;
            _vacancyService = vacancyService;
        }

        [HttpGet]
        public List<VacancyPreviewDto> GetVacancyPreviews()
        {
            return _vacancyService.GetVacanciesPreviews();
        }

        [HttpGet("{id}")]
        public VacancyFullDto GetVacancy(int id)
        {
            return _vacancyService.GetVacancy(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVacancy(VacancyCreateDto vacancyCreateDto)
        {
            var userId = await _userService.GetUserId(User);
            await _vacancyService.CreateVacancy(vacancyCreateDto, userId);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditVacancy(VacancyEditDto vacancyEditDto)
        {
            var userId = await _userService.GetUserId(User);
            await _vacancyService.EditVacancy(vacancyEditDto, userId);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            var userId = await _userService.GetUserId(User);
            await _vacancyService.DeleteVacancy(id, userId);
            return Ok();
        }
    }
}
