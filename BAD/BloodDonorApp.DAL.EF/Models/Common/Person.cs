using System;
using System.ComponentModel.DataAnnotations;


namespace BloodDonorApp.DAL.EF.Models.Common
{
    public abstract class Person : Record
    {

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }
}