using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.Query.Predicates;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;

namespace BloodDonorApp.BL.EF.QueryObjects
{
    public class SampleStationQueryObject : QueryObjectBase<SampleStationDto, SampleStation, DTO.Filters.SampleStationFilterDto, IQuery<SampleStation>>
    {
        public SampleStationQueryObject(IMapper mapper, IQuery<SampleStation> query) : base(mapper, query)
        {
        }

        protected override IQuery<SampleStation> ApplyWhereClause(IQuery<SampleStation> query, SampleStationFilterDto filter)
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

        private static SimplePredicate FilterCity(SampleStationFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.City))
            {
                return null;
            }
            return new SimplePredicate(nameof(SampleStation.City), ValueComparingOperator.StringContains, filter.City);
        }
        private static SimplePredicate FilterName(SampleStationFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Name))
            {
                return null;
            }
            return new SimplePredicate(nameof(SampleStation.Name), ValueComparingOperator.StringContains, filter.Name);
        }
    }
}
