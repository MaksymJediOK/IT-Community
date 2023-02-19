using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Post> PostRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Forum> ForumRepository { get; }
        IGenericRepository<Tag> TagRepository { get; }
        IGenericRepository<Like> LikeRepository { get; }
        IGenericRepository<Bookmark> BookmarkRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<Company> CompanyRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        Task SaveAsync();
    }
}
