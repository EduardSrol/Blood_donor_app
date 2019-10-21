using System;

namespace BloodDonorApp.Infrastructue.Query.Predicates.Operators
{
    public abstract class Record
    {
        public DateTime? Updated { get; set; }
        public Guid UpdatedById { get; set; }
    }
}