namespace IT_Community.Server.Infrastructure.Dtos.CompanyDTOs
{
    public class CompanyFullDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
        public string? Site { get; set; }
        public int EmployeesAmount { get; set; }
    }
}
