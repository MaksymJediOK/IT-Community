using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.VacancyDTOs
{
    public class VacancyFullDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImageSrc { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyImageSrc { get; set; }
        public string CompanyDescription { get; set; }
        public int CompanyEmployeesAmount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
