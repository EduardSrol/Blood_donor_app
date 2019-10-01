using BAD.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAD.DAL
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void Dispose();
        IRepository<T> GetRepository<T>();
        DbEntityEntry Entry(object e);
    }
}
