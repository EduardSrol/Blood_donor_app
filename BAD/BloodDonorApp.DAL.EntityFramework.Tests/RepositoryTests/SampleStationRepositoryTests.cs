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
    public class SampleStationRepositoryTests
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory = Initializer.Container.Resolve<IUnitOfWorkFactory>();

        private readonly IRepository<SampleStation> sampleStationRepository = Initializer.Container.Resolve<IRepository<SampleStation>>();

        private readonly Guid realSampleStationId1 = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a0");

        private readonly Guid realSampleStationId2 = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a1");

        private readonly Guid fakeSampleStationId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a2");

        [Test]
        public async Task GetSampleStationAsync_AlreadyStoredInDB_ReturnsCorrectSampleStation_TestOne()
        {
            SampleStation sampleStation;

            using (unitOfWorkFactory.Create())
            {
                sampleStation = await sampleStationRepository.GetByIdAsync(realSampleStationId1);
            }

            Assert.AreEqual(sampleStation.Id, realSampleStationId1);

        }

        [Test]
        public async Task GetSampleStationAsync_AlreadyStoredInDB_ReturnsCorrectSampleStation_TestTwo()
        {
            SampleStation sampleStation;

            using (unitOfWorkFactory.Create())
            {
                sampleStation = await sampleStationRepository.GetByIdAsync(realSampleStationId2);
            }

            Assert.AreEqual(sampleStation.Id, realSampleStationId2);

        }

        [Test]
        public async Task GetSampleStationAsync_NotInDB_ReturnsNullSampleStation()
        {
            SampleStation sampleStation;

            using (unitOfWorkFactory.Create())
            {
                sampleStation = await sampleStationRepository.GetByIdAsync(fakeSampleStationId);
            }

            Assert.IsNull(sampleStation);

        }

    }
}
