using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodDonorApp.Infrastructure
{

    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        #region SyncMethods
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(Guid id);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
//        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
//        bool Any(Expression<Func<TEntity, bool>> predicate);
//        TEntity First(Expression<Func<TEntity, bool>> predicate);
//        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
//        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        #endregion

        #region AsyncMethods
//        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
//        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
//        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);
//        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);

        #endregion
    }
}
