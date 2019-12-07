using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.Admins;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades
{
    public class AdminFacade : FacadeBase
    {
        private readonly IAdminService adminService;

        public AdminFacade(IUnitOfWorkFactory unitOfWorkFactory, IAdminService adminService) : base(unitOfWorkFactory)
        {
            this.adminService = adminService;
        }

        public async Task<Guid> RegisterAdmin(AdminDto model)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var id = adminService.RegisterAdminAsync(model);
                await uow.CommitAsync();
                return id;
            }
        }

        public async Task<bool> Login(string username, string password)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await adminService.AuthorizeAdminAsync(username, password);
            }
        }
    }
}
