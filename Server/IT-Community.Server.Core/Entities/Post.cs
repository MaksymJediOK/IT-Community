using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Community.Server.Core.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public string? Thumbnail { get; set; }
        public int ForumId { get; set; }
        public Forum? Forum { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
