using BAD.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace BAD.DAL
{
    public class DbContextRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext;
        protected DbSet<T> DbSet;

        public DbContextRepository(DbContext dataContext)
        {
            DbContext = dataContext;
            DbSet = DbContext.Set<T>();
        }
        public DbContextRepository(DbContext dataContext, DbSet<T> dbSet)
        {
            DbContext = dataContext;

            this.DbSet = dbSet;
        }
        //For mock purpose
        public DbContextRepository(DbSet<T> dbSet)
        {
            this.DbSet = dbSet;
        }

        #region Sync methods
        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            if (IsDetachedState(entity))
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (IsDetachedState(entity))
                {
                    DbSet.Attach(entity);
                }
            }

            DbSet.RemoveRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return DbSet.First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool asNoTracking)
        {
            return asNoTracking ? DbSet.AsNoTracking().Where(predicate) : DbSet.Where(predicate);
        }

        public void Update(T entity)
        {
            SetModifiedState(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            SetModifiedState(entities);
        }
        #endregion

        #region Async methods
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.CountAsync(predicate);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstAsync(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
        #endregion

        protected virtual void SetModifiedState(IEnumerable<T> entities)
        {
            DbSet.AddOrUpdate(entities.ToArray());
        }

        protected virtual void SetModifiedState(T entity)
        {
            DbSet.AddOrUpdate(entity);
        }

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