using BAD.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAD.Model
{
    public abstract class Person : Record
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }


    }
}