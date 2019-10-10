using BAD.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAD.Data
{
    public interface IRepository<TRecord>  where TRecord : class, IRecord, new()
    {

        #region SyncMethods
        void Insert(TRecord entity);
        void Insert(IEnumerable<TRecord> entities);
        void Delete(TRecord entity);
        void Delete(IEnumerable<TRecord> entities);
        void Update(TRecord entity);
        void Update(IEnumerable<TRecord> entities);
        IQueryable<TRecord> Where(Expression<Func<TRecord, bool>> predicate);
        bool Any(Expression<Func<TRecord, bool>> predicate);
        #endregion

        #region AsyncMethods
        Task<bool> AnyAsync(Expression<Func<TRecord, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TRecord, bool>> predicate);
        Task<TRecord> FirstAsync(Expression<Func<TRecord, bool>> predicate);
        Task<TRecord> FirstOrDefaultAsync(Expression<Func<TRecord, bool>> predicate);
        Task<TRecord> GetByIdAsync(int id);
        #endregion
    }
}
