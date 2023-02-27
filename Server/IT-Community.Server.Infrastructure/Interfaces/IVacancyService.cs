using IT_Community.Server.Infrastructure.Dtos.VacancyDTOs;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IVacancyService
    {
        Task CreateVacancy(VacancyCreateDto vacancyCreateDto, string userId);
        Task EditVacancy(VacancyEditDto vacancyEditDto, string userId);
        Task DeleteVacancy(int id, string userId);
        List<VacancyPreviewDto> GetVacanciesPreviews();
        VacancyFullDto GetVacancy(int id);

    }
}
