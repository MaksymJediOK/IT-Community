using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IT_Community.Server.Infrastructure.Dtos.CompanyDTOs
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Site { get; set; }
        public int EmployeesAmount { get; set; }
    }
}
