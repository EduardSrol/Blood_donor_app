using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonorApp.DAL.EF.Models.Common
{
    public abstract class Institution : Record
    {

        public string City { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }
    }
}