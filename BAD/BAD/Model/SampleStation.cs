using BAD.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Model
{
    public class SampleStation : Institution
    {

        public string WebLink { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}