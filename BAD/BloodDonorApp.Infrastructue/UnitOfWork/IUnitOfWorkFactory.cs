using System;

namespace BloodDonorApp.Infrastructure.UnitOfWork

{
    public interface IUnitOfWorkFactory : IDisposable
    {
        /// <summary>
        /// Creates a new unit of work
        /// </summary>
        IUnitOfWork Create();
        
        /// <summary>
        /// Gets the unit of work in the current scope
        /// </summary>
        /// <returns></returns>
        IUnitOfWork GetUnitOfWorkInstance();
    }
}
