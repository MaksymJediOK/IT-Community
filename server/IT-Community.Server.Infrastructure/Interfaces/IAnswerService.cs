using IT_Community.Server.Infrastructure.Dtos.AnswerDTOs;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IAnswerService
    {
        Task CreateAnswer(AnswerCreateDto createAnswerDto, string userId);
        List<AnswerPreviewDto> GetAnswerPreviews(int vacancyId, string userId);
        Task DeleteAnswer(int answerId, string userId);
    }
}
