namespace IT_Community.Server.Infrastructure.Dtos.CommentDTOs
{
    public class CommentCreateDto
    {
        public int? ParentId { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
    }
}
