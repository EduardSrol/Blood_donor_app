using Castle.Windsor;
using System;
using System.Data.Entity;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.EF;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.UnitOfWork;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;

namespace BloodDonorApp.DAL.EF.Config
{
    public class EFInstaller : IWindsorInstaller
    {
        //internal const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Database=BLOODDONORAPP-DB;Trusted_Connection=True;MultipleActiveResultSets=true";
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
