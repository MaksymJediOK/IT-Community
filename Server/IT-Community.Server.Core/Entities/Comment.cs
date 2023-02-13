using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Comment? Parent { get; set; }
        public int? ParentId { get; set; }
        public string? Body { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
