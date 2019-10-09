using BAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAD.Model
{
    public class BloodDonation : Record, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public virtual CommonUser Donor { get; set; }

        public virtual CommonUser Applicant { get; set; }

        public virtual SampleStation SampleStation { get; set; }

        public int SampleVolume { get; set; }

        public DateTime Date { get; set; }


    }
}