using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Services.Accounts.Registration
{
    public interface IAdminCheckoutAccountAvailabilityService
    {
        /// <summary>
        /// Checks if username already exists
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if username doesn't already exist</returns>
        Task<bool> IsUsernameAvailable(string userName);

    }
}
