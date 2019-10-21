using System;

namespace BloodDonorApp.Infrastructue.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
