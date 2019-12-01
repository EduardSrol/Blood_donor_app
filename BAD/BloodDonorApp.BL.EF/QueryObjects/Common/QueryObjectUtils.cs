using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.Infrastructure.Query.Predicates;

namespace BloodDonorApp.BL.EF.QueryObjects.Common
{
    public static class QueryObjectUtils
    {
        public static void AddIfDefined(IPredicate categoryPredicate, ICollection<IPredicate> definedPredicates)
        {
            if (categoryPredicate != null)
            {
                definedPredicates.Add(categoryPredicate);
            }
        }
    }
}
