using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.CompanyDTOs
{
    public class CompanyPreviewDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageSrc { get; set; }
        public int EmployeesAmount { get; set; }
    }
}
