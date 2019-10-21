using BloodDonorApp.Infrastructue.Data;
using BloodDonorApp.Infrastructue.Query.Predicates.Operators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonorApp.DAL.EF.Models
{
    public class Institution : Record, IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }
    }
}