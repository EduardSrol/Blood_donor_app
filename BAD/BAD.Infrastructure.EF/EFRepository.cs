using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace BAD.Infrastructure.EF
{
    public class EFRepository<T> : Data.IRepository<T> where T : class, Data.IEntity, new()
    {
        private readonly EFUnitOfWorkFactory factory;
        protected DbContext DbContext => ((EFUnitOfWork)factory.GetUnitOfWorkInstance()).Context;

        public EFRepository(EFUnitOfWorkFactory factory)
        {
            this.factory = factory;
        }

        #region Sync methods
        public void Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            DbContext.Set<T>().Add(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            if (IsDetachedState(entity))
            {
                DbContext.Set<T>().Attach(entity);
            }

            DbContext.Set<T>().Remove(entity);
        }

        public void Delete(Guid id)
        {
            var entity = DbContext.Set<T>().Find(id);
            if (entity != null)
            {
                DbContext.Set<T>().Remove(entity);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (IsDetachedState(entity))
                {
                    DbContext.Set<T>().Attach(entity);
                }
            }

            DbContext.Set<T>().RemoveRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Any(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool asNoTracking)
        {
            return asNoTracking ? DbContext.Set<T>().AsNoTracking().Where(predicate) : DbContext.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            var foundEntity = DbContext.Set<T>().Find(entity.Id);
            DbContext.Entry(foundEntity).CurrentValues.SetValues(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }
        #endregion

        #region Async methods
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().CountAsync(predicate);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().FirstAsync(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
        #endregion

        protected virtual bool IsDetachedState(T entity)
        {
            return DbContext.Entry(entity).State == EntityState.Detached;
        }

        #region NotImplemented
        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}