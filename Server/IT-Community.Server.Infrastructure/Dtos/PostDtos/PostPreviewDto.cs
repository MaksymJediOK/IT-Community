using IT_Community.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.PostDtos
{
    public class PostPreviewDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public string? Thumbnail { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Tags { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}
