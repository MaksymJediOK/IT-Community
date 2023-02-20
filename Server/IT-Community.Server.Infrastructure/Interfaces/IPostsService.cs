using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IPostsService
    {
        List<PostPreviewDto> GetPostPreview();
        List<PostPreviewDto> GetSortedFilteredPostPreview(string? searchString, string? orderBy, string? dateFilter, List<int>? tagIds = null);
        Task<PostFullDto> GetPost(int id);
        Task CreatePost(PostCreateDto postCreateDto, string userId);
        Task EditPost(PostCreateDto postCreateDto, string userId, int postId);
        Task DeletePost(int id, string userId);
        bool IsExist(int id);
    }
}
