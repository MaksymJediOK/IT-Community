using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IT_Community.Server.Core.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _ctx;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DataContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }

        public void Delete(TEntity obj)
        {
            if (_ctx.Entry(obj).State == EntityState.Detached)
            {
                _dbSet.Attach(obj);
            }
            _dbSet.Remove(obj);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> GetAll(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           params string[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task Insert(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public void Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _ctx.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetListBySpec(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification).ToList();
        }

        public TEntity? GetFirstBySpec(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification).FirstOrDefault();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbSet, specification);
        }
    }
}
