using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;

namespace BloodDonorApp.BL.EF.DTO
{
    public class SampleStationDto : InstitutionDto
    {
        public string WebLink { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
