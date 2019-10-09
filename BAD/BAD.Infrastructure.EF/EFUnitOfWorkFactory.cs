using BAD.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAD.Infrastructure.EF
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