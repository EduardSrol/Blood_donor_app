using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.Accounts.Registration
{
    public class AdminCheckoutAccountAvailabilityService : CrudQueryServiceBase<Admin, AdminAccountAvailabilityDto, AdminFilterDto>, IAdminCheckoutAccountAvailabilityService
    {

        public AdminCheckoutAccountAvailabilityService(IMapper mapper, IRepository<Admin> adminRepository, QueryObjectBase<AdminAccountAvailabilityDto, Admin, AdminFilterDto, IQuery<Admin>> adminQueryObject)
            : base(mapper, adminRepository, adminQueryObject) { }

        public async Task<bool> IsUsernameAvailable(string userName)
        {
            var queryResult = await Query.ExecuteQuery(new AdminFilterDto() { UserName = userName});
            return queryResult.Items.SingleOrDefault() == null;
        }
    }
}
