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
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.Query.Predicates;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;

namespace BloodDonorApp.BL.EF.QueryObjects
{
    public class BloodDonationQueryObject : QueryObjectBase<BloodDonationDto, BloodDonation, BloodDonationFilterDto, IQuery<BloodDonation>>
    {
        public BloodDonationQueryObject(IMapper mapper, IQuery<BloodDonation> query) : base(mapper, query) { }
        protected override IQuery<BloodDonation> ApplyWhereClause(IQuery<BloodDonation> query, BloodDonationFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
            QueryObjectUtils.AddIfDefined(FilterSampleStation(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterApplicant(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterDonor(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterBloodTypes(filter), definedPredicates);

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

        private static SimplePredicate FilterSampleStation(BloodDonationFilterDto filter)
        {
            if (filter.SampleStationId.Equals(Guid.Empty))
            {
                return null;
            }
            return new SimplePredicate(nameof(BloodDonation.SampleStationId),ValueComparingOperator.Equal, filter.SampleStationId);
        }

        private static SimplePredicate FilterDonor(BloodDonationFilterDto filter)
        {
            if (filter.DonorId.Equals(Guid.Empty))
            {
                return null;
            }
            return new SimplePredicate(nameof(BloodDonation.DonorId), ValueComparingOperator.Equal, filter.DonorId);
        }
        private static SimplePredicate FilterApplicant(BloodDonationFilterDto filter)
        {
            if (filter.ApplicantId.Equals(Guid.Empty))
            {
                return null;
            }
            return new SimplePredicate(nameof(BloodDonation.ApplicantId), ValueComparingOperator.Equal, filter.ApplicantId);
        }
        private static CompositePredicate FilterBloodTypes(BloodDonationFilterDto filter)
        {
            if (filter.BloodTypes == null || !filter.BloodTypes.Any())
            {
                return null;
            }
            var bloodTypePredicates = new List<IPredicate>(filter.BloodTypes
                .Select(bloodType => new SimplePredicate(
                    nameof(BloodDonation.BloodType),
                    ValueComparingOperator.Equal,
                    bloodType)));
            return new CompositePredicate(bloodTypePredicates, LogicalOperator.OR);
        }
    }
}
