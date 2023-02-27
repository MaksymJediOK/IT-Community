using Ardalis.Specification;
using IT_Community.Server.Core.Entities;

namespace IT_Community.Server.Infrastructure.Specifications
{
    public static class Posts
    {
        public class ByUserIdWithUserAndTagsCommentsLikes : Specification<Post>
        {
            public ByUserIdWithUserAndTagsCommentsLikes(string userId)
            {
                Query
                    .Where(x => x.UserId == userId)
                    .Include(x => x.Tags)
                    .Include(x => x.Comments)
                    .Include(x => x.User)
                    .Include(x => x.Likes);
            }
        }

        public class WithUserAndTagsCommentsLikes : Specification<Post>
        {
            public WithUserAndTagsCommentsLikes()
            {
                Query
                    .Include(x => x.Tags)
                    .Include(x => x.Comments)
                    .Include(x => x.User)
                    .Include(x => x.Likes);
            }
        }

        public class ByIdWithAllFields : Specification<Post>
        {
            public ByIdWithAllFields(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Tags)
                    .Include(x => x.Comments)
                    .Include(x => x.User)
                    .Include(x => x.Likes)
                    .Include(x => x.Forum);
            }
        }
    }
}
