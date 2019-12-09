using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.EF;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.UnitOfWork;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;

namespace BloodDonorApp.DAL.EF.Config
{
    public class EFInstaller : IWindsorInstaller
    {
        internal const string ConnectionString = "Data source=dblood.database.windows.net;Database=BLOODDONORAPP-DB;User ID=dBloodAdmin;Password=dBlood2019;Trusted_Connection=False;Encrypt=True;MultipleActiveResultSets=true";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Func<DbContext>>()
                    .Instance(() => new BDADbContext())
                    .LifestyleTransient(),
                Component.For<IUnitOfWorkFactory>()
                    .ImplementedBy<EFUnitOfWorkFactory>()
                    .LifestyleSingleton(),
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(EFRepository<>))
                    .LifestyleTransient(),
                Component.For(typeof(IQuery<>))
                    .ImplementedBy(typeof(EFQuery<>))
                    .LifestyleTransient()
            );
        }

    }
}
