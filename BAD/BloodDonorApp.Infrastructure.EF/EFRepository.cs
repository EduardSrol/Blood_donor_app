using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;
using BloodDonorApp.Infrastructure.Data;

namespace BloodDonorApp.Infrastructure.EF
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly EFUnitOfWorkFactory factory;
        protected DbContext DbContext => ((EFUnitOfWork)factory.GetUnitOfWorkInstance()).Context;

        public EFRepository(EFUnitOfWorkFactory factory)
        {
            this.factory = factory;
        }

        #region Sync methods
        public void Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            if (IsDetachedState(entity))
            {
                DbContext.Set<TEntity>().Attach(entity);
            }

            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(Guid id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                DbContext.Set<TEntity>().Remove(entity);
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (IsDetachedState(entity))
                {
                    DbContext.Set<TEntity>().Attach(entity);
                }
            }

            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity GetById(Guid id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Any(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().First(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool asNoTracking)
        {
            return asNoTracking ? DbContext.Set<TEntity>().AsNoTracking().Where(predicate) : DbContext.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            var foundEntity = DbContext.Set<TEntity>().Find(entity.Id);
            DbContext.Entry(foundEntity).CurrentValues.SetValues(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }
        #endregion

        #region Async methods
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().FirstAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

        }
        #endregion

        protected virtual bool IsDetachedState(TEntity entity)
        {
            return DbContext.Entry(entity).State == EntityState.Detached;
        }
    }
}