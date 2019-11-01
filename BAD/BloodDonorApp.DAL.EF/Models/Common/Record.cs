using System;

namespace BloodDonorApp.DAL.EF.Models.Common
{
    public abstract class Record
    {
        public DateTime? Updated { get; set; }
        public Guid UpdatedById { get; set; }
    }
}