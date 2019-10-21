using BloodDonorApp.BL.EF.DTO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Interface
{
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        Task<UserDetailModel> GetByIdAsync(int id);
    }
}
