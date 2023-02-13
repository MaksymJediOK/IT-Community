using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface ICommentService
    {
        List<CommentPostDto> GetCommentsWithReplies(int postId);
        Task CreateComment(CommentCreateDto commentCreateDto, string userId);
        Task UpdateComment(CommentUpdateDto commentUpdateDto, string userId);
        Task DeleteComment(int commentId, string userId);
    }
}
