using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.DAL.EF.Enums;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class UserFilterDto : FilterDtoBase
    {
        public UserType UserType { get; set; }
    }
}
