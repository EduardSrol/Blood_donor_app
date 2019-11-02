using System;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserDto : UserDto
    {

        public BloodType BloodType { get; set; }

        public CommonUserType Type { get; set; }

        public string Description { get; set; }

        public Guid? HospitalId { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }

        public string FullName { get; set; }

        public string FullBN { get; set; }

    }
}
