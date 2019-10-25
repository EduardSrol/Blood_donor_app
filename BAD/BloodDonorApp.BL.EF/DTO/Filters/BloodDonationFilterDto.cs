using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.DAL.EF.Enums;
using System;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class BloodDonationFilterDto : FilterDtoBase
    {
        public Guid SampleStationId { get; set; }

        public Guid DonorId { get; set; }

        public Guid ApplicantId { get; set; }
    }
}
