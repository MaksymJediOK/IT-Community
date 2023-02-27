namespace IT_Community.Server.Core.Entities
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
    }
}