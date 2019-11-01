using System;

namespace BloodDonorApp.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; set; }

        string TableName { get; }
    }
}
