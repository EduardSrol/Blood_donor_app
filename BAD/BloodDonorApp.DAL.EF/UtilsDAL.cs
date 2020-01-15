using BloodDonorApp.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.DAL.EF
{
    public static class UtilsDAL
    {
        public static bool CompatibleBloodTypes(BloodType bloodTypeDonor, BloodType bloodTypeApplicant)
        {
            if (bloodTypeDonor.Equals(bloodTypeApplicant))
            {
                return true;
            }
            if (bloodTypeDonor.Equals(BloodType.Ominus))
            {
                return true;
            }
            if (bloodTypeApplicant.Equals(BloodType.ABplus))
            {
                return true;
            }
            Dictionary<BloodType, List<BloodType>> blood = new Dictionary<BloodType, List<BloodType>> {
                { BloodType.Oplus, new List<BloodType>() { BloodType.Aplus, BloodType.Bplus }},
                { BloodType.Bminus, new List<BloodType>() { BloodType.ABminus, BloodType.Bplus }},
                { BloodType.Aminus, new List<BloodType>() { BloodType.ABminus, BloodType.ABplus }}
            };
            if (blood.ContainsKey(bloodTypeDonor))
            {
                return blood[bloodTypeDonor].Contains(bloodTypeApplicant);
            }
            return false;
        }
    }
}
