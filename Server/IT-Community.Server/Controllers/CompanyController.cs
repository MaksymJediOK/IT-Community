using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;
using IT_Community.Server.Infrastructure.Interfaces;
using IT_Community.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;

        public CompanyController(IUserService userService, ICompanyService companyService)
        {
            _userService = userService;
            _companyService = companyService;
        }

        /// <summary>
        /// Returns the list of companies
        /// </summary>
        [HttpGet]
        public List<CompanyPreviewDto> GetAllCompanyPreviews()
        {
            return _companyService.GetAllCompanyPreviews();
        }

        /// <summary>
        /// Gets company by id
        /// </summary>
        /// <param name="companyId">Company id</param>
        [HttpGet("{companyId}")]
        public async Task<CompanyFullDto> GetCompany(int companyId)
        {
            return await _companyService.GetCompany(companyId);
        }

        /// <summary>
        /// Creates a new company
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCompany([FromForm]CompanyCreateDto company)
        {
            var userId = await _userService.GetUserId(User);
            await _companyService.CreateCompany(company, userId);

            return Ok();
        }

        /// <summary>
        /// Updates company by id
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCompany([FromForm]CompanyEditDto company)
        {
            var userId = await _userService.GetUserId(User);
            await _companyService.UpdateCompany(company, userId);

            return Ok();
        }

        /// <summary>
        /// Deletes company by id
        /// </summary>
        /// <param name="companyId">Id of the company to delete</param>
        [HttpDelete("{companyId}")]
        [Authorize]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var userId = await _userService.GetUserId(User);
            await _companyService.DeleteCompany(companyId, userId);

            return Ok();
        }

        /// <summary>
        /// Approves company by id
        /// </summary>
        /// <param name="companyId">Id of the company to approve</param>
        [HttpPut("{companyId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveCompany(int companyId)
        {
            var userId = await _userService.GetUserId(User);
            await _companyService.ApproveCompany(companyId, userId);

            return Ok();
        }
    }
}
