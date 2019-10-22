using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.DAL.EF.Enums;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class BloodDonationFilterDto : FilterDtoBase
    {
        public BloodType BloodType { get; set; }
    }
}
