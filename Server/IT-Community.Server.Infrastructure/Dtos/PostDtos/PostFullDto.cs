using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;

namespace IT_Community.Server.Infrastructure.Dtos.PostDtos
{
    public class PostFullDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public string? Thumbnail { get; set; }
        public string? ImageSrc { get; set; }
        public int ForumId { get; set; }
        public string ForumName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<TagDto> Tags { get; set; }
        public int Likes { get; set; }
        public List<CommentPostDto> Comments { get; set; }
    }
}
