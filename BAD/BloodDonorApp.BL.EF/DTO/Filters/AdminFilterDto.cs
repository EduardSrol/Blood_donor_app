using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.DAL.EF.Enums;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class AdminFilterDto : FilterDtoBase
    {
        public CommonUserType UserType { get; set; }

        public string UserName { get; set; }
    }
}
