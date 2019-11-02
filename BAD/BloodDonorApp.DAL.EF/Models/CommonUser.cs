using BloodDonorApp.DAL.EF.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloodDonorApp.DAL.EF.Models.Common;
using BloodDonorApp.Infrastructure;

namespace BloodDonorApp.DAL.EF.Models
{
    public class CommonUser : User, IEntity
    {
        //maybe photo

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(BDADbContext.CommonUsers);
        public int UUN { get; set; }

        public string PrefixBN { get; set; }

        public string SufixBN { get; set; }

        public BloodType BloodType { get; set; }

        public CommonUserType Type { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Hospital))]
        public Guid? HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }

    }
}