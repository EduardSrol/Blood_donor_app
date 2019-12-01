using BloodDonorApp.BL.EF.DTO.Common;
using System;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class BloodDonationFilterDto : FilterDtoBase
    {
        public Guid SampleStationId { get; set; }

        public Guid DonorId { get; set; }

        public Guid ApplicantId { get; set; }

        public BloodType[] BloodTypes { get; set; }
    }
}
