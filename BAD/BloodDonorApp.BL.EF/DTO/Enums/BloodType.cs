using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO.Enums
{
    public enum BloodType
    {
        [Display(Name="O+")]
        Oplus = 0,
        [Display(Name="O-")]
        Ominus = 1,
        [Display(Name="A+")]
        Aplus = 2,
        [Display(Name="A-")]
        Aminus = 3,
        [Display(Name="B+")]
        Bplus = 4,
        [Display(Name="B-")]
        Bminus = 5,
        [Display(Name="AB+")]
        ABplus = 6,
        [Display(Name="AB-")]
        ABminus = 7
    }
}
