using System;
using System.ComponentModel.DataAnnotations;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserDto : UserDto
    {
        [Required]
        public int UUN { get; set; }

        [Required]
        [Display(Name = "Blood type")]
        public BloodType BloodType { get; set; }

        public string Description { get; set; }

        [Display(Name = "Hospital ID")]
        public Guid? HospitalId { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }

        [Display(Name = "Full birth number")]
        public string FullBN { get; set; }

        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }
    }
}
