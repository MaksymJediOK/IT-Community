using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;

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
