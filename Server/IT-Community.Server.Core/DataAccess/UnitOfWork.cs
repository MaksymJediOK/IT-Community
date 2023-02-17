using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
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

        public IGenericRepository<User> userRepository;

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(_ctx);
                }
                return userRepository;
            }
        }

        public IGenericRepository<Forum> forumRepository;

        public IGenericRepository<Forum> ForumRepository
        {
            get
            {
                if(this.forumRepository == null)
                {
                    this.forumRepository = new GenericRepository<Forum>(_ctx);
                }
                return forumRepository;
            }
        }

        public IGenericRepository<Tag> tagRepository;

        public IGenericRepository<Tag> TagRepository
        {
            get
            {
                if(this.tagRepository == null)
                {
                    this.tagRepository = new GenericRepository<Tag>(_ctx);
                }
                return tagRepository;
            }
        }

        public IGenericRepository<Like> likeRepository;

        public IGenericRepository<Like> LikeRepository
        {
            get
            {
                if(this.likeRepository == null)
                {
                    this.likeRepository = new GenericRepository<Like>(_ctx);
                }
                return likeRepository;
            }
        }

        public IGenericRepository<Bookmark> bookmarkRepository;

        public IGenericRepository<Bookmark> BookmarkRepository
        {
            get
            {
                if(this.bookmarkRepository == null)
                {
                    this.bookmarkRepository = new GenericRepository<Bookmark>(_ctx);
                }
                return bookmarkRepository;
            }
        }

        public IGenericRepository<Comment> commentRepository;

        public IGenericRepository<Comment> CommentRepository
        {
            get
            {
                if(this.commentRepository == null)
                {
                    this.commentRepository = new GenericRepository<Comment>(_ctx);
                }
                return commentRepository;
            }
        }

        public IGenericRepository<Company> companyRepository;

        public IGenericRepository<Company> CompanyRepository
        {
            get
            {
                if(this.companyRepository == null)
                {
                    this.companyRepository = new GenericRepository<Company>(_ctx);
                }
                return companyRepository;
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

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
