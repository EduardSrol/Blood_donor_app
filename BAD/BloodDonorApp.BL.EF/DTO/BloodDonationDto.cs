using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;

namespace BloodDonorApp.BL.EF.DTO
{
    public class BloodDonationDto : DtoBase
    {
        public Guid DonorId { get; set; }

        public Guid ApplicantId { get; set; }

        public Guid SampleStationId { get; set; }

        public int SampleVolume { get; set; }

        public DateTime Date { get; set; }
    }
}
