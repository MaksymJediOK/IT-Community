using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core
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
        public int Likes { get; set; }
        public DateTime Date { get; set; }
        public string? Thumbnail { get; set; }
        public Forum? Forums { get; set; }
        public User? Users { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
