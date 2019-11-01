using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloodDonorApp.DAL.EF.Enums;
using BloodDonorApp.DAL.EF.Models.Common;
using BloodDonorApp.Infrastructure;

namespace BloodDonorApp.DAL.EF.Models
{
    public class Admin : User, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(BDADbContext.Admins);
        public AdminType AdminType { get; set; }

        [ForeignKey(nameof(Hospital))]
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}