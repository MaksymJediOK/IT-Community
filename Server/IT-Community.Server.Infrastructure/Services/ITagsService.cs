using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface ITagsService
    {
        List<TagDto> GetTags();
        Task BatchCreateTags(List<TagDto> tagDtos);
        Task DeleteTag(int id);
        bool IsExist(int id);
    }
}
