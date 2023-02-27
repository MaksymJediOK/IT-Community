namespace IT_Community.Server.Infrastructure.Dtos.VacancyDTOs
{
    public class VacancyCreateDto
    {
        public int Salary { get; set; }
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
    }
}
