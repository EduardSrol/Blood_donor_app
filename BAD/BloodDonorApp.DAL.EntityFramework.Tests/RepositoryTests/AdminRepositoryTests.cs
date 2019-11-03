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

        private readonly Guid realAdminId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a6");

        private readonly Guid fakeAdminId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a7");

        [Test]
        public async Task GetAdminAsync_AlreadyStoredInDB_ReturnsCorrectAdmin()
        {
            Admin admin;

            using (unitOfWorkFactory.Create())
            {
                admin = await adminRepository.GetByIdAsync(realAdminId);
            }

            Assert.AreEqual(admin.Id, realAdminId);

        }

        [Test]
        public async Task GetAdminAsync_NotInDB_ReturnsNullAdmin()
        {
            Admin admin;

            using (unitOfWorkFactory.Create())
            {
                admin = await adminRepository.GetByIdAsync(fakeAdminId);
            }

            Assert.IsNull(admin);

        }
    }
}
