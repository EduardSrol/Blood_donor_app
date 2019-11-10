using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.Admins
{
    public class AdminService : CrudQueryServiceBase<Admin, AdminDto, AdminFilterDto>, IAdminService
    {
        public AdminService(IMapper mapper, IRepository<Admin> adminRepository, QueryObjectBase<AdminDto, Admin, AdminFilterDto, IQuery<Admin>> adminListQuery)
            : base(mapper, adminRepository, adminListQuery) { }

        public async Task<AdminDto[]> GetAdminByAdminTypes(AdminType[] adminTypes)
        {
            var queryResult = await Query.ExecuteQuery(new AdminFilterDto() { AdminTypes = adminTypes});
            return queryResult.Items.ToArray();
        }

        public async Task<AdminDto> GetAdminByUserName(string userName)
        {
            var queryResult = await Query.ExecuteQuery(new AdminFilterDto() { UserName = userName });
            return queryResult.Items.SingleOrDefault();
        }
    }
    
}
