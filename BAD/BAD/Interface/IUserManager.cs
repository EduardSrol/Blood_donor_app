using BAD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BAD.Interface
{
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        Task<UserDetailModel> GetByIdAsync(int id);
    }
}
