using System;
using System.Threading;

namespace BloodDonorApp.Infrastructure.UnitOfWork
{
    public abstract class UnitOfWorkFactoryBase : IUnitOfWorkFactory
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