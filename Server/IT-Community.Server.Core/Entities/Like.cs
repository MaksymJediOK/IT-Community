using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
    }
}
