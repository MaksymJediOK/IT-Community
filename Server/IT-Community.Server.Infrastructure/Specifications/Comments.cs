using Ardalis.Specification;
using IT_Community.Server.Core.Entities;

namespace IT_Community.Server.Infrastructure.Specifications
{
    public static class Comments
    {
        public class ByPostIdAndParentIdWithUserAndComments : Specification<Comment>
        {
            public ByPostIdAndParentIdWithUserAndComments(int postId, int? parentId)
            {
                Query
                    .Where((x => x.PostId == postId && x.ParentId == parentId))
                    .Include(x => x.User)
                    .Include(x => x.Comments)
                    .ThenInclude(x => x.User);
            }
        }
    }
}
