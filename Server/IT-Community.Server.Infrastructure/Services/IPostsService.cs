using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IPostsService
    {
        List<PostPreviewDto> GetPostPreview();
        List<PostPreviewDto> GetPopularPosts(string timePeriod);
        Task<PostFullDto> GetPost(int id);
        Task CreatePost(PostCreateDto postCreateDto, string userId);
        Task EditPost(PostCreateDto postCreateDto, string userId, int postId);
        Task DeletePost(int id);
        bool IsExist(int id);
    }
}
