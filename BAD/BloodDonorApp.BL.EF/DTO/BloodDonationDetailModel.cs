using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO
{
    class BloodDonationDetailModel
    {
        [Display(Name = "BloodDonationDonorID", ResourceType = typeof(Resources.Models))]
        public Guid? DonorId { get; set; }

        [Display(Name = "BloodDonationApplicantID", ResourceType = typeof(Resources.Models))]
        public Guid? ApplicantId { get; set; }

        [Display(Name = "BloodDonationSampleStationID", ResourceType = typeof(Resources.Models))]
        public Guid? SampleStationId { get; set; }

        [Display(Name = "BloodDonationSampleVolume", ResourceType = typeof(Resources.Models))]
        public int SampleVolume { get; set; }

        [Display(Name = "BloodDonationDateTime", ResourceType = typeof(Resources.Models))]
        public DateTime? Date { get; set; }
    }
}
