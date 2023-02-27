using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface ILikeService
    {
        Task ToggleLike(int postId, string userId);
        List<PostPreviewDto> GetLikedPosts(string userId);
        Task<JsonResult> IsLiked(int postId, string userId);
    }
}
