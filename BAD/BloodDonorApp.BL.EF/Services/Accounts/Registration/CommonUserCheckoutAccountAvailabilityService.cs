using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.Accounts.Registration
{
    public class CommonUserCheckoutAccountAvailabilityService : CrudQueryServiceBase<CommonUser, CommonUserAccountAvailabilityDto, CommonUserFilterDto>, ICommonUserCheckoutAccountAvailabilityService
    {


        public CommonUserCheckoutAccountAvailabilityService(IMapper mapper, IRepository<CommonUser> commonUserRepository, QueryObjectBase<CommonUserAccountAvailabilityDto, CommonUser, CommonUserFilterDto, IQuery<CommonUser>> commonUserQueryObject)
            : base(mapper, commonUserRepository, commonUserQueryObject) { }

        public async Task<bool> IsUsernameAvailable(string userName)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { UserName = userName });
            return queryResult.Items.SingleOrDefault() == null;
        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { Email = email });
            return queryResult.Items.SingleOrDefault() == null;
        }
    }
}
