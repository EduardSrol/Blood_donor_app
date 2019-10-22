using System;

namespace BloodDonorApp.Infrastructure.UnitOfWork

{
    interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork Create();

        IUnitOfWork GetUnitOfWorkInstance();
    }
}
