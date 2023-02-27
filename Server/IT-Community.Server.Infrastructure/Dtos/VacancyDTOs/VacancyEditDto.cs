namespace IT_Community.Server.Infrastructure.Dtos.VacancyDTOs
{
    public class VacancyEditDto
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
    }
}

