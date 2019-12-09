using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserEditProfileExtendedDto : DtoBase
    {
        public Guid? HospitalId { get; set; }

        public bool Approved { get; set; }

        public BloodType BloodType { get; set; }

        public bool IsDeleted { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string Description { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public UserType Type { get; set; }

        public bool Active { get; set; }
    }
}
