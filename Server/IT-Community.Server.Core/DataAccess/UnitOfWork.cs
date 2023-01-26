using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly DataContext _ctx = new DataContext(new DbContextOptions<DataContext>());
        private readonly DataContext _ctx;

        public UnitOfWork(DataContext _ctx)
        {
            this._ctx = _ctx;
        }

        public IGenericRepository<Post> postRepository;

        public IGenericRepository<Post> PostRepository
        {
            get
            {
                if(this.postRepository == null)
                {
                    this.postRepository = new GenericRepository<Post>(_ctx);
                }
                return postRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
