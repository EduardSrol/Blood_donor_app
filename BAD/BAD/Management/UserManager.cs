using BAD.DTO;
using BAD.Interface;
using BAD.Management.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BAD.Management
{
    public class UserManager : ManagerBase, IUserManager
    {



        public Task<UserDetailModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}