using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.UnitOfWork;
using NUnit.Framework;

namespace BloodDonorApp.DAL.EntityFramework.Tests.RepositoryTests
{
    public class CommonUserRepositoryTests
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory = Initializer.Container.Resolve<IUnitOfWorkFactory>();

        private readonly IRepository<CommonUser> commonUserRepository =
            Initializer.Container.Resolve<IRepository<CommonUser>>();

        private readonly Guid realCommonUserId1 = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a3");

        private readonly Guid realCommonUserId2 = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a4");

        private readonly Guid realCommonUserId3 = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a5");

        private readonly Guid fakeCommonUserId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a6");


        [Test]
        public async Task GetCommonUserAsync_AlreadyStoredInDB_ReturnsCorrectCommonUser_TestOne()
        {
            CommonUser commonUser;

            using (unitOfWorkFactory.Create())
            {
                commonUser = await commonUserRepository.GetByIdAsync(realCommonUserId1);
            }

            Assert.AreEqual(commonUser.Id, realCommonUserId1);

        }

        [Test]
        public async Task GetCommonUserAsync_AlreadyStoredInDB_ReturnsCorrectCommonUser_TestTwo()
        {
            CommonUser commonUser;

            using (unitOfWorkFactory.Create())
            {
                commonUser = await commonUserRepository.GetByIdAsync(realCommonUserId2);
            }

            Assert.AreEqual(commonUser.Id, realCommonUserId2);

        }

        [Test]
        public async Task GetCommonUserAsync_AlreadyStoredInDB_ReturnsCorrectCommonUser_TestThree()
        {
            {
                CommonUser commonUser;

                using (unitOfWorkFactory.Create())
                {
                    commonUser = await commonUserRepository.GetByIdAsync(realCommonUserId3);
                }

                Assert.AreEqual(commonUser.Id, realCommonUserId3);

            }
        }

        [Test]
        public async Task GetCommonUserAsync_NotInDB_ReturnsNullCommonUser_TestThree()
        {
            {
                CommonUser commonUser;

                using (unitOfWorkFactory.Create())
                {
                    commonUser = await commonUserRepository.GetByIdAsync(fakeCommonUserId);
                }

                Assert.IsNull(commonUser);

            }
        }
    }
}
