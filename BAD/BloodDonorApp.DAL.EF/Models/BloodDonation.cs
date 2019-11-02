using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BloodDonorApp.DAL.EF.Enums;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.DAL.EF.Models.Common;
using BloodDonorApp.Infrastructure;

namespace BloodDonorApp.DAL.EF.Models
{
    public class BloodDonation : Record, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(BDADbContext.BloodDonations);

        [ForeignKey(nameof(Donor))]
        public Guid? DonorId { get; set; }

        public CommonUser Donor { get; set; }

        public BloodType BloodType { get; set; }

        [ForeignKey(nameof(Applicant))]
        public Guid? ApplicantId { get; set; }
        public virtual CommonUser Applicant { get; set; }

        [ForeignKey(nameof(SampleStation))]
        public Guid? SampleStationId { get; set; }
        public virtual SampleStation SampleStation { get; set; }

        public int SampleVolume { get; set; }

        public DateTime? Date { get; set; }


    }
}