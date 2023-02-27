using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IBookmarkService
    {
        Task ToggleBookmark(int postId, string userId);
        List<PostPreviewDto> GetBookmarkedPosts(string userId);
        Task<JsonResult> IsBookmarked(int postId, string userId);
    }
}