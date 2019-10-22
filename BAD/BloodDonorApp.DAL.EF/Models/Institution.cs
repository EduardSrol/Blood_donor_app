using BloodDonorApp.Infrastructure.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonorApp.DAL.EF.Models
{
    public abstract class Institution : Record, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }
    }
}