using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects;
using BloodDonorApp.BL.Tests.QueryObjectTests.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure.Query.Predicates;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;
using NUnit.Framework;

namespace BloodDonorApp.BL.Tests.QueryObjectTests
{
    [TestFixture]
    public class CommonUserQueryObjectTests
    {
        [Test]
        public async Task ApplyWhereClause_SimpleFilterWithBloodType_ReturnsCorrectCompositePredicate()
        {
            const BloodType desiredBloodType1 = BloodType.Ominus;
            const BloodType desiredBloodType2 = BloodType.Bplus;
            const BloodType desiredBloodType3 = BloodType.ABplus;
            var mockManager = new QueryMockManager();
            var expectedPredicate = new CompositePredicate(
                new List<IPredicate>
                {
                    new SimplePredicate(nameof(CommonUser.BloodType), ValueComparingOperator.Equal, desiredBloodType1),
                    new SimplePredicate(nameof(CommonUser.BloodType), ValueComparingOperator.Equal, desiredBloodType2),
                    new SimplePredicate(nameof(CommonUser.BloodType), ValueComparingOperator.Equal, desiredBloodType3)
                }, LogicalOperator.OR);
            var mapperMock = mockManager.ConfigureMapperMock<CommonUser, CommonUserDto, CommonUserFilterDto>();
            var queryMock = mockManager.ConfigureQueryMock<CommonUser>();
            var commonUserQueryObject = new CommonUserQueryObject(mapperMock.Object, queryMock.Object);

            var unused = await commonUserQueryObject.ExecuteQuery(new CommonUserFilterDto { BloodTypes = new[] { desiredBloodType1, desiredBloodType2, desiredBloodType3 } });

            Assert.AreEqual(mockManager.CapturedPredicate, expectedPredicate);
        }
    }
}
