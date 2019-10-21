using System;
using System.Threading.Tasks;

namespace BloodDonorApp.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
//        void Dispose();
    }
}
