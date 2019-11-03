using Castle.Windsor;
using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.UnitOfWork;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;
using BloodDonorApp.Infrastructure.EF;
using BloodDonorApp.DAL.EF;
using BloodDonorApp.DAL.EF.Enums;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.DAL.EntityFramework.Tests.Config
{
    public class EntityFrameworkTestInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Func<DbContext>>()
                    .Instance(InitializeDatabase)
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

        private static DbContext InitializeDatabase()
        {
            var context = new BDADbContext();
            context.Admins.RemoveRange(context.Admins);
            context.CommonUsers.RemoveRange(context.CommonUsers);
            context.Hospitals.RemoveRange(context.Hospitals);
            context.SampleStations.RemoveRange(context.SampleStations);
            context.BloodDonations.RemoveRange(context.BloodDonations);
            context.SaveChanges();

            var pp = new SampleStation
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a0"),
                Name = "NTS Poprad",
                Street = "Bratislavská 8",
                City = "Poprad"
            };

            var ke = new SampleStation
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a1"),
                Name = "NTS Košice",
                Street = "Hlavná 25",
                City = "Košice"
            };

            var ba = new Hospital
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a2"),
                Name = "Kramáre",
                Street = "Limbová 2645/5",
                City = "Bratislava"
            };

            var karlik = new CommonUser
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a3"),
                FirstName = "Karol",
                LastName = "Valko",
                BloodType = BloodType.Ominus,
                UUN = 1
            };

            var laco = new CommonUser
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a4"),
                FirstName = "Laco",
                LastName = "Praporcik",
                BloodType = BloodType.ABplus,
                UUN = 2,
                Hospital = ba
            };

            var henrich = new CommonUser
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a5"),
                FirstName = "Henrich",
                LastName = "Lako",
                BloodType = BloodType.Bplus,
                UUN = 3,
                Hospital = ba,
                Email = "heno.lako@gmail.com"
            };

            var jano = new Admin
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a6"),
                FirstName = "Jano",
                LastName = "Dovjo",
                Email = "j.bigD@gmail.com",
                UserName = "JanBoss"
            };

            var numOne = new BloodDonation
            {
                Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a7"),
                Applicant = henrich,
                Donor = karlik,
                SampleStation = ke,
                SampleVolume = 450,
                BloodType = karlik.BloodType
            };

            context.Hospitals.AddOrUpdate(ba);
            context.SampleStations.AddOrUpdate(pp);
            context.SampleStations.AddOrUpdate(ke);
            context.BloodDonations.AddOrUpdate(numOne);
            context.Admins.AddOrUpdate(jano);
            context.CommonUsers.AddOrUpdate(karlik);
            context.CommonUsers.AddOrUpdate(laco);
            context.CommonUsers.AddOrUpdate(henrich);
            context.SaveChanges();

            return context;
        }
    }
}
