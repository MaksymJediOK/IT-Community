using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.CommentDTOs
{
    public class CommentPostDto
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
        public int ParentId { get; set; }
        public List<CommentPostDto> ReplyList { get; set; }
    }
}
