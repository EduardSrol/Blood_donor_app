using System.ComponentModel.DataAnnotations.Schema;


namespace BloodDonorApp.DAL.EF.Models
{
    public abstract class User : Person
    {
        public string UserName { get; set; }

        public Enums.UserType UserType { get; set; }

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