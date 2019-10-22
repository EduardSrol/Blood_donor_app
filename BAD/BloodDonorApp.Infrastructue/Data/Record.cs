using System;

namespace BloodDonorApp.Infrastructure.Data
{
    public abstract class Record
    {
        public DateTime? Updated { get; set; }
        public Guid UpdatedById { get; set; }
    }
}