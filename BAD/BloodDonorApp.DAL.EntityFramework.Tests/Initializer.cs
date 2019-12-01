using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.DAL.EF;
using BloodDonorApp.DAL.EntityFramework.Tests.Config;
using Castle.Windsor;
using NUnit.Framework;

namespace BloodDonorApp.DAL.EntityFramework.Tests
{
    [SetUpFixture]
    public class Initializer
    {
        internal static readonly IWindsorContainer Container = new WindsorContainer();

        [OneTimeSetUp]
        public void InitializeBusinessLayerTests()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BDADbContext>());
            Container.Install(new EntityFrameworkTestInstaller());
        }
    }
}
