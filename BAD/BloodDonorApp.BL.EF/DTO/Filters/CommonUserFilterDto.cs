using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO.Filters
{
    public class CommonUserFilterDto : FilterDtoBase
    {
        public int? UUN { get; set; }

        public CommonUserType[] CommonUserTypes { get; set; }

        public BloodType[] BloodTypes { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
