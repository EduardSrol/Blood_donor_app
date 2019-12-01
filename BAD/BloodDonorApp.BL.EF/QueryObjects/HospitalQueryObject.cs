using BloodDonorApp.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure.Query.Predicates;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;

namespace BloodDonorApp.BL.EF.QueryObjects
{
    public class HospitalQueryObject : QueryObjectBase<HospitalDto, Hospital, DTO.Filters.HospitalFilterDto, IQuery<Hospital>>
    {
        public HospitalQueryObject(IMapper mapper, IQuery<Hospital> query) : base(mapper, query)
        {
        }

        protected override IQuery<Hospital> ApplyWhereClause(IQuery<Hospital> query, HospitalFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
            QueryObjectUtils.AddIfDefined(FilterCity(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterName(filter), definedPredicates);

            switch (definedPredicates.Count)
            {
                case 0:
                    return query;
                case 1:
                    return query.Where(definedPredicates.First());
                default:
                {
                    var wherePredicate = new CompositePredicate(definedPredicates);
                    return query.Where(wherePredicate);
                }
            }
        }

        private static SimplePredicate FilterCity(HospitalFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.City))
            {
                return null;
            }
            return new SimplePredicate(nameof(Hospital.City), ValueComparingOperator.StringContains, filter.City);
        }
        private static SimplePredicate FilterName(HospitalFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Name))
            {
                return null;
            }
            return new SimplePredicate(nameof(Hospital.Name), ValueComparingOperator.StringContains, filter.Name);
        }
    }
}
