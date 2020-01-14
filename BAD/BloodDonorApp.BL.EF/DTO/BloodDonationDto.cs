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
    public class BloodDonationDto : DtoBase
    {
        [Display(Name = "Donor ID")]
        public Guid DonorId { get; set; }

        [Display(Name = "Donor name")]
        public string DonorName { get; set; }
        [Display(Name = "Applicant ID")]
        public Guid ApplicantId { get; set; }

        [Display(Name = "Applicant name")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "Sample Station is required!")]
        [Display(Name = "Sample Station ID")]
        public Guid SampleStationId { get; set; }

        [Display(Name = "Sample Station name")]
        public string SampleStationName { get; set; }

        [Required(ErrorMessage = "Blood type is required!")]
        [Display(Name = "Blood type")]
        public BloodType BloodType { get; set; }

        [Required(ErrorMessage = "Sample volume is required!")]
        [Display(Name = "Sample volume")]
        public int SampleVolume { get; set; }

        [Required(ErrorMessage = "Date is required!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime Date { get; set; }
    }
}
