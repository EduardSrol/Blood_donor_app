using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserAccountAvailabilityDto : DtoBase
    {
        public string Email { get; set; }

        public string Username { get; set; }
    }
}
