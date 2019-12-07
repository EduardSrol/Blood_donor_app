using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO.Common
{
    public abstract class UserDto : PersonDto
    {
        public string UserName { get; set; }

        public string Password
        {
            get => Password;
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                //TODO: find way to hash password
            }


        }

        [StringLength(100)]
        public string PasswordSalt { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }
    }
}
