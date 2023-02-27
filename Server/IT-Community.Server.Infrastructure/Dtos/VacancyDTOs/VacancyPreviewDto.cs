namespace IT_Community.Server.Infrastructure.Dtos.VacancyDTOs
{
    public class VacancyPreviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ImageSrc { get; set; }
    }
}
