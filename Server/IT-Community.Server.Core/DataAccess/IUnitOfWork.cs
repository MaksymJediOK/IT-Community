using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Core.GenericRepository;

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
        IGenericRepository<Vacancy> VacancyRepository { get; }
        IGenericRepository<Answer> AnswerRepository { get; }
        Task SaveAsync();
    }
}
