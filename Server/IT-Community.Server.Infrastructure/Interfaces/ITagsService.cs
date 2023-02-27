using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;

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
