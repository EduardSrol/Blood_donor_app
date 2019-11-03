using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.DAL.EF.Models;
using NUnit.Framework;

namespace BloodDonorApp.DAL.EntityFramework.Tests.RepositoryTests
{
    public class BloodDonationRepositoryTests
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory = Initializer.Container.Resolve<IUnitOfWorkFactory>();

        private readonly IRepository<BloodDonation> bloodDonationRepository = Initializer.Container.Resolve<IRepository<BloodDonation>>();

        private readonly Guid realBloodDonationId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a7");

        private readonly Guid fakeBloodDonationId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a8");


        [Test]
        public async Task GetAdminAsync_AlreadyStoredInDB_ReturnsCorrectBloodDonation()
        {
            BloodDonation donation;

            using (unitOfWorkFactory.Create())
            {
                donation = await bloodDonationRepository.GetByIdAsync(realBloodDonationId);
            }
            
            Assert.AreEqual(donation.Id, realBloodDonationId);
        }

        [Test]
        public async Task GetAdminAsync_NotInDB_ReturnsNullBloodDonation()
        {
            BloodDonation donation;

            using (unitOfWorkFactory.Create())
            {
                donation = await bloodDonationRepository.GetByIdAsync(fakeBloodDonationId);
            }

            Assert.IsNull(donation);
        }
    }
}
