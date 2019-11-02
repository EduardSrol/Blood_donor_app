using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;
using BloodDonorApp.Infrastructure.UnitOfWork;
using Castle.Windsor;

namespace BloodDonorApp.DAL.EntityFramework.Tests.RepositoryTests
{
    [TestFixture]
    public class AdminRepositoryTests
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory = Initializer.Container.Resolve<IUnitOfWorkFactory>();

        private readonly IRepository<Admin> adminRepository = Initializer.Container.Resolve<IRepository<Admin>>();

        private readonly Guid realAdminGuid = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a7");

        private readonly Guid fakeAdminGuid = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a8");

        [Test]
        public async Task GetAdminAsync_ReturnsCorrectAdmin()
        {
            Admin admin;

            using (unitOfWorkFactory.Create())
            {
                admin = await adminRepository.GetByIdAsync(realAdminGuid);
            }

            Assert.AreEqual(admin.Id, realAdminGuid);
        }
    }
}
