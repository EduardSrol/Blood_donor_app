using BloodDonorApp.BL.EF.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class CommonUserFilterDto : FilterDtoBase
    {
        public int? UUN { get; set; }

        public CommonUserType[] CommonUserTypes { get; set; }

        public BloodType[] BloodTypes { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
