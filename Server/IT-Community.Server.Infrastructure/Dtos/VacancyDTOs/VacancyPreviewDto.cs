using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
