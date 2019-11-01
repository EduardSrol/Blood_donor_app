using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloodDonorApp.DAL.EF.Models.Common;
using BloodDonorApp.Infrastructure;

namespace BloodDonorApp.DAL.EF.Models
{
    public class SampleStation : Institution, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(BDADbContext.SampleStations);
        public string WebLink { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}