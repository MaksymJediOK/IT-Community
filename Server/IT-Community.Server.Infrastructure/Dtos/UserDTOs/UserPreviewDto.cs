using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Dtos.UserDTOs
{
    public class UserPreviewDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? ImageSrc { get; set; }
    }
}