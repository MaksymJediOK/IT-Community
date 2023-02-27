using Ardalis.Specification;
using System.Linq.Expressions;

namespace IT_Community.Server.Core.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           params string[] includeProperties);
        TEntity GetById(object id);
        Task Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Delete(object id);
        IEnumerable<TEntity> GetListBySpec(ISpecification<TEntity> specification);
        TEntity? GetFirstBySpec(ISpecification<TEntity> specification);
    }
}
