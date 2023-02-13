using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.CommentDTOs
{
    public class CommentCreateDto
    {
        public int? ParentId { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
    }
}
