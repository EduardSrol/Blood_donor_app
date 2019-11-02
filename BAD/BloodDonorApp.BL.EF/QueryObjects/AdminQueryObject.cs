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
    public class AdminQueryObject : QueryObjectBase<AdminDto, Admin, AdminFilterDto, IQuery<Admin>>
    {
        public AdminQueryObject(IMapper mapper, IQuery<Admin> query) : base(mapper, query) { }

        protected override IQuery<Admin> ApplyWhereClause(IQuery<Admin> query, AdminFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
            QueryObjectUtils.AddIfDefined(FilterAdmins(filter), definedPredicates);
            QueryObjectUtils.AddIfDefined(FilterUserName(filter), definedPredicates);

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

        private static CompositePredicate FilterAdmins(AdminFilterDto filter)
        {
            if (filter.AdminTypes == null || !filter.AdminTypes.Any())
            {
                return null;
            }
            var adminTypePredicates = new List<IPredicate>(filter.AdminTypes
                .Select(adminType => new SimplePredicate(
                    nameof(Admin.Type),
                    ValueComparingOperator.Equal,
                    adminType)));
            return new CompositePredicate(adminTypePredicates, LogicalOperator.OR);
        }

        private static SimplePredicate FilterUserName(AdminFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.UserName))
            {
                return null;
            }
            return new SimplePredicate(nameof(Admin.UserName), ValueComparingOperator.StringContains, filter.UserName);
        }
    }
}
