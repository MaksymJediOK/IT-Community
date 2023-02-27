using Microsoft.AspNetCore.Http;

namespace IT_Community.Server.Infrastructure.Dtos.CompanyDTOs
{
    public class CompanyEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Site { get; set; }
        public int EmployeesAmount { get; set; }
    }
}
