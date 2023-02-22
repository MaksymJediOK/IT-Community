using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IT_Community.Server.Infrastructure.Dtos.AnswerDTOs
{
    public class AnswerCreateDto
    {
        public int VacancyId { get; set; }
        public string? Description { get; set; }
        public IFormFile CVFile { get; set; }
    }
}
