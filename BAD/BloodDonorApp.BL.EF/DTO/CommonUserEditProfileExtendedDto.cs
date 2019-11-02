using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserEditProfileExtendedDto : CommonUserEditProfileDto
    {
        public Guid? HospitalId { get; set; }

        public bool Approved { get; set; }
    }
}
