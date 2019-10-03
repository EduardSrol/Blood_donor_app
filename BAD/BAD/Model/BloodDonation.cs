using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Model
{
    public class BloodDonation : Record
    {
        public virtual User Donor { get; set; }

        public virtual User Applicant { get; set; }

        public virtual SampleStation SampleStation { get; set; }

        public int SampleVolume { get; set; }

        public DateTime Date { get; set; }


    }
}