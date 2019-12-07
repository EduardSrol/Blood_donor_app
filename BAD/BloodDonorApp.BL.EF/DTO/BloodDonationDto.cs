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
        public Guid DonorId { get; set; }

        public Guid ApplicantId { get; set; }
        [Required(ErrorMessage = "Sample Station is required!")]

        public Guid SampleStationId { get; set; }
        [Required(ErrorMessage = "Blood type is required!")]

        public BloodType BloodType { get; set; }
        [Required(ErrorMessage = "Sample volume is required!")]

        public int SampleVolume { get; set; }
        [Required(ErrorMessage = "Date is required!")]

        public DateTime Date { get; set; }
    }
}
