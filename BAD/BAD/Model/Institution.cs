using BAD.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Model
{
    public class Institution : Record
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }
    }
}