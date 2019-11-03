using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;

namespace BloodDonorApp.BL.EF.Services.Accounts.Registration
{
    public class CheckoutAccountAvailabilityService : ServiceBase, ICheckoutAccountAvailabilityService
    {
        private readonly IRepository<Admin> adminRepository;


        public CheckoutAccountAvailabilityService(IMapper mapper, IRepository<Admin> adminRepository) : base(mapper)
        {
            this.adminRepository = adminRepository;
        }

        public async Task<bool> IsUsernameAvailable(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            throw new NotImplementedException();
        }
    }
}
