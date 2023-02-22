using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core.Entities.Vacancies
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int VacancyId { get; set; }
        public Vacancy? Vacancy { get; set; }
        public string? Description { get; set; }
        public string ResumePath { get; set; }
    }
}
