using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.Interface;
using BloodDonorApp.BL.EF.Management.BaseModel;
using System;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Management
{
    public class UserManager : ManagerBase, IUserManager
    {

        public async Task<UserDetailModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}