using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BAD.Infrastructure.UnitOfWork
{
    public abstract class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        protected readonly AsyncLocal<IUnitOfWork> UOWInstance
            = new AsyncLocal<IUnitOfWork>();

        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        public abstract IUnitOfWork Create();

        /// <summary>
        /// Gets the unit of work in the current scope.
        /// </summary>
        public IUnitOfWork GetUnitOfWorkInstance()
        {
            return UOWInstance != null ? UOWInstance.Value : throw new InvalidOperationException("UoW not created");
        }

        public void Dispose()
        {
            UOWInstance.Value?.Dispose();
            UOWInstance.Value = null;
        }
    }
}