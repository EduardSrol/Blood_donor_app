using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Data.Entity;

namespace BloodDonorApp.Infrastructure.EF.UnitOfWork
{
    public class EFUnitOfWorkFactory : UnitOfWorkFactory
    {
        private readonly Func<DbContext> dbContextFactory;

        public EFUnitOfWorkFactory(Func<DbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public override IUnitOfWork Create()
        {
            UOWInstance.Value = new EFUnitOfWork(dbContextFactory);
            return UOWInstance.Value;
        }
    }
}