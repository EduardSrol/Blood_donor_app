using BAD.DTO;
using BAD.Interface;
using BAD.Management.BaseModel;
using BAD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BAD.Management
{
    public class UserManager : ManagerBase, IUserManager
    {



        public async Task<UserDetailModel> GetByIdAsync(int id)
        {
            var userModel = new UserDetailModel();
            var user = await unitOfWork.GetRepository<CommonUser>().Where(u => u.Id == id).FirstOrDefaultAsync();
            mapper.Map(user, userModel);
            return userModel;
        }
    }
}