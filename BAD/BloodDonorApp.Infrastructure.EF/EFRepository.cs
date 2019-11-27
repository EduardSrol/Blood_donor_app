using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;
using BloodDonorApp.Infrastructure.UnitOfWork;

namespace BloodDonorApp.Infrastructure.EF
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IUnitOfWorkFactory factory;
        protected DbContext DbContext => ((EFUnitOfWork)factory.GetUnitOfWorkInstance()).Context;

        public EFRepository(IUnitOfWorkFactory factory)
        {
            this.factory = factory;
        }

        #region Sync methods
        public void Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();

        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            DbContext.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            if (IsDetachedState(entity))
            {
                DbContext.Set<TEntity>().Attach(entity);
            }

            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                DbContext.Set<TEntity>().Remove(entity);
            }
            DbContext.SaveChanges();
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
            DbContext.SaveChanges();

        }

        public TEntity GetById(Guid id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            var foundEntity = DbContext.Set<TEntity>().Find(entity.Id);
            DbContext.Entry(foundEntity).CurrentValues.SetValues(entity);
            DbContext.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
            DbContext.SaveChanges();

        }

        #endregion

        #region Async methods
        public async Task UpdateAsync(TEntity entity)
        {
            var foundEntity = DbContext.Set<TEntity>().Find(entity.Id);
            DbContext.Entry(foundEntity).CurrentValues.SetValues(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }
        #endregion

        protected virtual bool IsDetachedState(TEntity entity)
        {
            return DbContext.Entry(entity).State == EntityState.Detached;
        }

    }
}