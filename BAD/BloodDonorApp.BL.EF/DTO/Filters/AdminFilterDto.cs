using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class AdminFilterDto : FilterDtoBase
    {
        public AdminType[] AdminTypes { get; set; }

        public string UserName { get; set; }

    }
}
