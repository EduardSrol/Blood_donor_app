using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAD.Infrastructure.UnitOfWork
{
    interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork Create();

        IUnitOfWork GetUnitOfWorkInstance();
    }
}
