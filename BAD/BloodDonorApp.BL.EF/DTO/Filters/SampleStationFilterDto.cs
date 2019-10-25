using BloodDonorApp.BL.EF.DTO.Common;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class SampleStationFilterDto : FilterDtoBase
    {
        public string City { get; set; }

        public string Name { get; set; }
    }
}
