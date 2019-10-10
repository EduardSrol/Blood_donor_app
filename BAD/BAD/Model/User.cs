using System;
using System.Collections.Generic;
using System.Linq;
using  System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BAD.Model
{
    public abstract class User : Person
    {
        public string UserName { get; set; }

        public Enums.UserType UserType { get; set; }

        [NotMapped]
        public string Password
        {
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                //TODO: find way to hash password
            }
        }
    }
}