using System;
using System.ComponentModel.DataAnnotations;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserDto : UserDto
    {
        public int UUN { get; set; }
        [Required]
        public BloodType BloodType { get; set; }
        [Required]
        public CommonUserType Type { get; set; }

        public string Description { get; set; }

        public Guid? HospitalId { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }

        public string FullBN { get; set; }

        public bool IsDeleted { get; set; }
    }
}
