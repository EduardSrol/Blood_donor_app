using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class ApplicantShortInfoDto : DtoBase
    {
        public string FirstName { get; set; }

        public int UUN { get; set; }

        public int Age { get; set; }

        public string Desription { get; set; }

        public BloodType BloodType { get; set; }

        public Guid? HospitalId { get; set; }

        //Maybe photo
    }
}
