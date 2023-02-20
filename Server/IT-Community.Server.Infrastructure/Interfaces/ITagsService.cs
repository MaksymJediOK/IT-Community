using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface ITagsService
    {
        List<TagDto> GetTags();
        Task BatchCreateTags(List<string> tagNames);
        Task DeleteTag(int id);
        bool IsExist(int id);
    }
}
