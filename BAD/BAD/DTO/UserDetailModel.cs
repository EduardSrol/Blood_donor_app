using BAD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BAD.DTO
{
    public class UserDetailModel
    {
        [Display(Name = "UserId", ResourceType = typeof(Resources.Models))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ValidationRequiredField", ErrorMessageResourceType = typeof(Resources.Models))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = "ValidationStringLengthRange", ErrorMessageResourceType = typeof(Resources.Models))]
        [Remote("VerifyUserName", "User", HttpMethod = "POST", AdditionalFields = "Id,__RequestVerificationToken", ErrorMessageResourceName = "ValidationUniqueField", ErrorMessageResourceType = typeof(Resources.Models))]
        [Display(Name = "UserName", Prompt = "UserName", ResourceType = typeof(Resources.Models))]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "ValidationStringLengthRange", ErrorMessageResourceType = typeof(Resources.Models))]
        [Display(Name = "UserFirstName", Prompt = "UserFirstNamePrompt", ResourceType = typeof(Resources.Models))]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "ValidationStringLengthMax", ErrorMessageResourceType = typeof(Resources.Models))]
        [Display(Name = "UserMiddleName", Prompt = "UserMiddleNamePrompt", ResourceType = typeof(Resources.Models))]
        public string MiddleName { get; set; }

        [Required(ErrorMessageResourceName = "ValidationRequiredField", ErrorMessageResourceType = typeof(Resources.Models))]
        [StringLength(100, ErrorMessageResourceName = "ValidationStringLengthMax", ErrorMessageResourceType = typeof(Resources.Models))]
        [Display(Name = "UserLastName", Prompt = "UserLastNamePrompt", ResourceType = typeof(Resources.Models))]
        public string LastName { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceName = "ValidationValidEmail", ErrorMessageResourceType = typeof(Resources.Models))]
        [Required(ErrorMessageResourceName = "ValidationRequiredField", ErrorMessageResourceType = typeof(Resources.Models))]
        [StringLength(250, ErrorMessageResourceName = "ValidationStringLengthMax", ErrorMessageResourceType = typeof(Resources.Models))]
        [Remote("VerifyEmail", "User", HttpMethod = "POST", AdditionalFields = "Id,__RequestVerificationToken", ErrorMessageResourceName = "ValidationUniqueField", ErrorMessageResourceType = typeof(Resources.Models))]
        [Display(Name = "UserEmail", Prompt = "UserEmailPrompt", ResourceType = typeof(Resources.Models))]
        public string Email { get; set; }

        [StringLength(20, ErrorMessageResourceName = "ValidationStringLengthMax", ErrorMessageResourceType = typeof(Resources.Models))]
        [Display(Name = "UserPhone", Prompt = "UserPhonePrompt", ResourceType = typeof(Resources.Models))]
        public string Phone { get; set; }

        [Display(Name = "UserEmailNotifications", ResourceType = typeof(Resources.Models))]
        public bool EmailNotifications { get; set; }

        [Display(Name = "UserType", ResourceType = typeof(Resources.Models))]
        public UserType UserType { get; set; }

        [Display(Name = "Updated", ResourceType = typeof(Resources.Models))]
        public DateTime Updated { get; set; }

        [Display(Name = "UserFullName", Prompt = "UserFullNamePrompt", ResourceType = typeof(Resources.Models))]
        public string FullName { get; set; }

        [Display(Name = "UserPassword", Prompt = "UserPasswordPrompt", ResourceType = typeof(Resources.Models))]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "UserIsPasswordSet", ResourceType = typeof(Resources.Models))]
        public bool IsPasswordSet
        {
            get
            {
                if (!string.IsNullOrEmpty(Password))
                    return true;

                return false;
            }
        }
    }
}