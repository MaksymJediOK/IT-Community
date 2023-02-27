using IT_Community.Server.Core.Entities.Vacancies;
using Microsoft.AspNetCore.Identity;

namespace IT_Community.Server.Core.Entities
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePhoto { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
