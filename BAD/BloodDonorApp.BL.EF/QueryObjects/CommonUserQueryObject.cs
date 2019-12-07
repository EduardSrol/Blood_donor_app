using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.Query.Predicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure.Query.Predicates.Operators;
using BloodDonorApp.Infrastructure.UnitOfWork;

namespace BloodDonorApp.BL.EF.QueryObjects
{
    public class CommonUserQueryObject : QueryObjectBase<CommonUserDto, CommonUser, DTO.Filters.CommonUserFilterDto, IQuery<CommonUser>>
    {
        public CommonUserQueryObject(IMapper mapper, IQuery<CommonUser> query) : base(mapper, query) { }
        protected override IQuery<CommonUser> ApplyWhereClause(IQuery<CommonUser> query, CommonUserFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
            QueryObjectUtils.AddIfDefined(FilterFullName(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterUserName(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterUun(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterEmail(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterPhone(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterBloodTypes(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterUserTypes(filter), definedPredicates);

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

        private static SimplePredicate FilterUun(CommonUserFilterDto filter)
        {
            if (filter.UUN.Equals(null))
            {
                return null;
            }
            return new SimplePredicate(nameof(CommonUser.UUN), ValueComparingOperator.Equal, filter.UUN);
        }

        private static SimplePredicate FilterUserName(CommonUserFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Username))
            {
                return null;
            }
            return new SimplePredicate(nameof(CommonUser.UserName), ValueComparingOperator.Equal, filter.Username);
        }

        private static SimplePredicate FilterFullName(CommonUserFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.FullName))
            {
                return null;
            }

            var fullName = nameof(CommonUser.FirstName);
            if (!string.IsNullOrWhiteSpace(nameof(CommonUser.MiddleName)))
            {
                fullName += " " + nameof(CommonUser.MiddleName);
            }

            fullName += " " + nameof(CommonUser.LastName);
            return new SimplePredicate(fullName, ValueComparingOperator.StringContains, filter.FullName);
        }

        private static SimplePredicate FilterEmail(CommonUserFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Email))
            {
                return null;
            }
            return new SimplePredicate(nameof(CommonUser.Email), ValueComparingOperator.Equal, filter.Email);
        }

        private static SimplePredicate FilterPhone(CommonUserFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Phone))
            {
                return null;
            }
            return new SimplePredicate(nameof(CommonUser.Phone), ValueComparingOperator.Equal, filter.Phone);
        }

        private static CompositePredicate FilterBloodTypes(CommonUserFilterDto filter)
        {
            if (filter.BloodTypes == null || !filter.BloodTypes.Any())
            {
                return null;
            }
            var bloodTypePredicates = new List<IPredicate>(filter.BloodTypes
                .Select(bloodType => new SimplePredicate(
                    nameof(CommonUser.BloodType),
                    ValueComparingOperator.Equal,
                    bloodType)));
            return new CompositePredicate(bloodTypePredicates, LogicalOperator.OR);
        }

        private static CompositePredicate FilterUserTypes(CommonUserFilterDto filter)
        {
            if (filter.UserTypes == null || !filter.UserTypes.Any())
            {
                return null;
            }
            var UserTypePredicates = new List<IPredicate>(filter.UserTypes
                .Select(UserType => new SimplePredicate(
                    nameof(CommonUser.Type),
                    ValueComparingOperator.Equal,
                    UserType)));
            return new CompositePredicate(UserTypePredicates, LogicalOperator.OR);
        }
    }
}
