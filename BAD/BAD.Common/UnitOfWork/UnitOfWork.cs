using BAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BAD.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, IRepository> repositoryByType;
        private bool disposed = false;
        protected readonly DbContext context;

        //public UnitOfWork(DbContext context)
        //{
        //    this.context = context;
        //}


        public void Commit()
        {
            // Update timestamp & author of change
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            // Update timestamp & author of change
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Reload entity from DB
        /// </summary>
        /// <param name="e">Entity</param>
        public void Refresh(object e)
        {
            context.Entry(e).Reload();
        }

        public bool AutoDetectChangesEnabled
        {
            get
            {
                return context.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                context.Configuration.AutoDetectChangesEnabled = value;
            }
        }

        public bool ValidateOnSaveEnabled
        {
            get
            {
                return context.Configuration.ValidateOnSaveEnabled;
            }
            set
            {
                context.Configuration.ValidateOnSaveEnabled = value;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}