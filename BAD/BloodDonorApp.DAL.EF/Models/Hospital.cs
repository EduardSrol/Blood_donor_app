using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloodDonorApp.DAL.EF.Models.Common;
using BloodDonorApp.Infrastructure;

namespace BloodDonorApp.DAL.EF.Models
{
    public class Hospital : Institution, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(BDADbContext.Hospitals);
    }
}