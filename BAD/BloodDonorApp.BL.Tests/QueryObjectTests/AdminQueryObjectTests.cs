using NUnit.Framework;
using System;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects;
using BloodDonorApp.BL.Tests.QueryObjectTests.Common;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.BL.Tests.QueryObjectTests
{
    [TestFixture]
    public class AdminQueryObjectTests
    {
        [Test]
        public async Task ApplyWhereClause_SimpleFilterWithUserName_ReturnsCorrectSimplePredicate()
        {
            const string desiredName = "JanBoss";
            var mockManager = new QueryMockManager();
            var expectedPredicate = new SimplePredicate(nameof(Admin.UserName), ValueComparingOperator.Equal, desiredName);
            var mapperMock = mockManager.ConfigureMapperMock<Admin, AdminDto, AdminFilterDto>();
            var queryMock = mockManager.ConfigureQueryMock<Admin>() ?? throw new ArgumentNullException("mockManager.ConfigureQueryMock<Admin>()");
            var adminQueryObject = new AdminQueryObject(mapperMock.Object, queryMock.Object);

            var unused = await adminQueryObject.ExecuteQuery(new AdminFilterDto { UserName = desiredName});

            Assert.AreEqual(mockManager.CapturedPredicate, expectedPredicate);
        }
    }
}
