using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
