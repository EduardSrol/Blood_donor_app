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
    public class ApplicantShortInfoDto : DtoBase
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        public int UUN { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        [Display(Name = "BloodType name")]
        public BloodType BloodType { get; set; }

        public Guid? HospitalId { get; set; }

    }
}
