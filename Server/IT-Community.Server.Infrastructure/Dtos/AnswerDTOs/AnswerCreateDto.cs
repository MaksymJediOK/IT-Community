using Microsoft.AspNetCore.Http;

namespace IT_Community.Server.Infrastructure.Dtos.AnswerDTOs
{
    public class AnswerCreateDto
    {
        public int VacancyId { get; set; }
        public string? Description { get; set; }
        public IFormFile CVFile { get; set; }
    }
}
