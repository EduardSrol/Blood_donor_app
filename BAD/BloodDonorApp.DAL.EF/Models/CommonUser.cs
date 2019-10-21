using BloodDonorApp.DAL.EF.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonorApp.DAL.EF.Models
{
    public class CommonUser : User
    {
        public int UUN { get; set; }

        public string PrefixBN { get; set; }

        public string SufixBN { get; set; }

        public BloodType BloodType { get; set; }

        [ForeignKey(nameof(Hospital))]
        public Guid? HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }
    }
}