using BAD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAD.Model
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