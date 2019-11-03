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
    public class HospitalRepositoryTests
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory = Initializer.Container.Resolve<IUnitOfWorkFactory>();

        private readonly IRepository<Hospital> hospitalRepository = Initializer.Container.Resolve<IRepository<Hospital>>();

        private readonly Guid realHospitalId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a2");

        private readonly Guid fakeHospitalId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a3");


        [Test]
        public async Task GetHospitalAsync_AlreadyStoredInDB_ReturnsCorrectHospital()
        {
            Hospital hospital;

            using (unitOfWorkFactory.Create())
            {
                hospital = await hospitalRepository.GetByIdAsync(realHospitalId);
            }

            Assert.AreEqual(hospital.Id, realHospitalId);

        }

        [Test]
        public async Task GetHospitalAsync_NotInDB_ReturnsNullHospital()
        {
            Hospital hospital;

            using (unitOfWorkFactory.Create())
            {
                hospital = await hospitalRepository.GetByIdAsync(fakeHospitalId);
            }

            Assert.IsNull(hospital);

        }
    }
}
