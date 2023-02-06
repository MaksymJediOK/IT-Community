using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface ILikeService
    {
        Task ToggleLike(int postId, string userId);
        List<PostPreviewDto> GetLikedPosts(string userId);
    }
}
