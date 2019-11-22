using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades.Common
{
    public abstract class FacadeBase
    {
        protected readonly IUnitOfWorkFactory UnitOfWorkFactory;

        protected FacadeBase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
