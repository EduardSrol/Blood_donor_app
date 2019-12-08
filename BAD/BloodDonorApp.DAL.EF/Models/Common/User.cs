using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloodDonorApp.DAL.EF.Enums;


namespace BloodDonorApp.DAL.EF.Models.Common
{
    public abstract class User : Person
    {
        public string UserName { get; set; }

        public UserType Type { get; set; }

        public string Roles { get; set; }

        [NotMapped]
        public string Password
        {
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