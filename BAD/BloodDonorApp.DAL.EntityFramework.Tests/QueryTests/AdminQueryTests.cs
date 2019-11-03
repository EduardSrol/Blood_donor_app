using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;
using NUnit.Framework;

namespace BloodDonorApp.DAL.EntityFramework.Tests.QueryTests
{
    public class AdminQueryTests
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory = Initializer.Container.Resolve<IUnitOfWorkFactory>();

        private readonly Guid janoId = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a6");


        [Test]
        public async Task ExecuteAsync_SimpleWherePredicate_ReturnsCorrectQueryResult()
        {
            QueryResult<Admin> actualQueryResult;
            var adminQuery = Initializer.Container.Resolve<IQuery<Admin>>();
            var expectedQuery = new QueryResult<Admin>(new List<Admin>
            {
                new Admin
                {
                    Id = Guid.Parse("ac4b45cc-7a23-46de-ad08-dffcd1a0d8a6"),
                    FirstName = "Jano",
                    LastName = "Dovjo",
                    Email = "j.bigD@gmail.com",
                    UserName = "JanBoss"
                }
            }, 1);

            using (unitOfWorkFactory.Create())
            {
                actualQueryResult = await adminQuery.Where(new SimplePredicate(nameof(Admin.UserName),
                    ValueComparingOperator.StringContains, "JanBoss")).ExecuteAsync();
            }

            Assert.AreEqual(actualQueryResult, expectedQuery);
        }
    }
}
