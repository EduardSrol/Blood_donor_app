using BloodDonorApp.Infrastructure.UnitOfWork;
using System;

namespace BloodDonorApp.Infrastructue.UnitOfWork

{
    interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork Create();

        IUnitOfWork GetUnitOfWorkInstance();
    }
}
