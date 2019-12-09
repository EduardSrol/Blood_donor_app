using BloodDonorApp.BL.EF.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO
{
    public class CommonUserRegistrationDto
    {

        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(64, ErrorMessage = "Your first name is too long!")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(64, ErrorMessage = "Your last name is too long!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "This is not valid email address!")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Birthdate is required!")]
        //[DataType(DataType.Date)]
        //public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 30")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Blood type is reqiured!")]
        [Range(1, 8, ErrorMessage = "Blood type is reqiured!")]
        public BloodType BloodType { get; set; }

        [Required(ErrorMessage = "Role is required!")]
        [Range(4, 5, ErrorMessage = "Role is required!")]
        public CommonUserType Type { get; set; }

        public string Description { get; set; }
    }
}
