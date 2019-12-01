using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BloodDonorApp.Infrastructure.EF.UnitOfWork
{
    public class EFUnitOfWork : Infrastructure.UnitOfWork.UnitOfWorkBase
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

        protected override void CommitCore()
        {
            Context.SaveChanges();
        }

        protected override async Task CommitCoreAsync()
        {
            await Context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            Context.Dispose();
        }
    }
}