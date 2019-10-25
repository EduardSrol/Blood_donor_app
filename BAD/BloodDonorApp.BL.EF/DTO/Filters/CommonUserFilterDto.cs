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
        public int UUN { get; set; }

        public UserType UserType { get; set; }

        public BloodType BloodType { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
