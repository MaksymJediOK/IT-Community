using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Community.Server.Core.Entities.Vacancies
{
    public class Vacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
