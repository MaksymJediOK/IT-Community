using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IPostsService
    {
        List<PostPreviewDto> GetPostPreview();
        Task<List<PostPreviewDto>> GetUserPosts(User user);
        List<PostPreviewDto> GetSortedFilteredPostPreview(string? searchString, string? orderBy, string? dateFilter, List<int>? tagIds = null);
        Task<PostFullDto> GetPost(int id);
        Task CreatePost(PostCreateDto postCreateDto, string userId);
        Task EditPost(PostCreateDto postCreateDto, string userId, int postId);
        Task DeletePost(int id, string userId);
        bool IsExist(int id);
    }
}
