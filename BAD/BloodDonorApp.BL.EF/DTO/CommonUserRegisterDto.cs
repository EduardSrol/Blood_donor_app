using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;


namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserRegisterDto : DtoBase
    {

        public string PrefixBN { get; set; }

        public string SufixBN { get; set; }

        public BloodType BloodType { get; set; }

        public int HospitalId { get; set; }

        public string UserName { get; set; }

        public CommonUserType UserType { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
