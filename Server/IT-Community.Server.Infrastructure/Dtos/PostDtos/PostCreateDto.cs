using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.PostDtos
{
    public class PostCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public IFormFile? ImageFile { get; set; }
        public List<int>? TagsId { get; set; }
        public int ForumId { get; set; }
    }
}
