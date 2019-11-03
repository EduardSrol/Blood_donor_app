using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Services.Accounts.Registration
{
    public interface ICheckoutAccountAvailabilityService
    {
        /// <summary>
        /// Checks if username already exists
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if username doesn't already exist</returns>
        Task<bool> IsUsernameAvailable(string userName);

        /// <summary>
        /// Checks if email already exists
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if email doesn't already exist</returns>
        Task<bool> IsEmailAvailable(string email);
    }
}
