using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.CommentDTOs
{
    public class CommentUpdateDto
    {
        public string Body { get; set; }
        public int CommentId { get; set; }
    }
}
