using System;
using System.Data.Entity;

namespace BAD.Infrastructure.EF
{
    public class EFUnitOfWork : UnitOfWork.UnitOfWork
    {
        /// <summary>
        /// Gets the <see cref="DbContext"/>.
        /// </summary>
        public DbContext Context { get; }

        public EFUnitOfWork(Func<DbContext> dbContextFactory)
        {
            this.Context = dbContextFactory?.Invoke()
                ?? throw new ArgumentException("Db context factory cant be null!");
        }
    }
}