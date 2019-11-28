﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloodDonorApp.DAL.EF.Enums;


namespace BloodDonorApp.DAL.EF.Models.Common
{
    public abstract class User : Person
    {
        public string UserName { get; set; }


        [NotMapped]
        public string Password
        {
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                //TODO: find way to hash password
            }
        }

        [Required, StringLength(100)]
        public string PasswordSalt { get; set; }

        [Required, StringLength(100)]
        public string PasswordHash { get; set; }

    }
}