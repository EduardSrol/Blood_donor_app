using System.ComponentModel.DataAnnotations;

namespace BloodDonorApp.DAL.EF.Enums
{
    public enum BloodType
    {
        [Display(Name = "O+")]
        Oplus = 0,
        [Display(Name = "O-")]
        Ominus = 1,
        [Display(Name = "A+")]
        Aplus = 2,
        [Display(Name = "A-")]
        Aminus = 3,
        [Display(Name = "B+")]
        Bplus = 4,
        [Display(Name = "B-")]
        Bminus = 5,
        [Display(Name = "AB+")]
        ABplus = 6,
        [Display(Name = "AB-")]
        ABminus = 7
    }
}