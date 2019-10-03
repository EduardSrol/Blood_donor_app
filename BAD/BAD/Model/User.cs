using BAD.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAD.Model
{
    public class User : Person
    {
        [MaxLength(100)]
        public string UserName { get; set; }

        public BloodType BloodType { get; set; }

        public UserType UserType { get; set; }

        public Hospital Hospital { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }

        public int UUN { get; set; }

        [NotMapped]
        public string Password
        {
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                //TODO: find way to hash password
            }
        }
    }
}