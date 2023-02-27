using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyFullDto> GetCompany(int id);
        Task CreateCompany(CompanyCreateDto companyCreateDto, string userId);
        Task UpdateCompany(CompanyEditDto companyEditDto, string userId);
        Task DeleteCompany(int companyId, string userId);
        Task ApproveCompany(int companyId, string userId);
        List<CompanyPreviewDto> GetAllCompanyPreviews();
    }
}
