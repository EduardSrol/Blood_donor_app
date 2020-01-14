using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserEditProfileExtendedDto : DtoBase
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Blood type")]
        public BloodType BloodType { get; set; }

        public UserType Type { get; set; }

        public bool Active { get; set; }

        public bool Approved { get; set; }

        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Hospital ID")]
        public Guid? HospitalId { get; set; }

        public string Description { get; set; }
    }
}
