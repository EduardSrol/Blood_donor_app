using BAD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BAD.Model
{
    public class Admin : Person
    {
        public string UserName { get; set; }

        public UserType UserType { get; set; }

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