using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IBookmarkService
    {
        Task ToggleBookmark(int postId, string userId);
        List<PostPreviewDto> GetBookmarkedPosts(string userId);
    }
}