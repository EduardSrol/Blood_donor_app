using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.DAL.EF.Enums
{
    public enum UserType
    {
        RootAdmin = 1,
        HospitalAdmin = 2,
        StationAdmin = 3,
        Donor = 4,
        Applicant = 5
    }
}
