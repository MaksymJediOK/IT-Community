using IT_Community.Server.Core.Entities;
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
        void Save();
    }
}
