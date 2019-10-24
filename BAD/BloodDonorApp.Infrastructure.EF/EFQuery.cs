using BloodDonorApp.Infrastructure.Data;
using BloodDonorApp.Infrastructure.EF.UnitOfWork;
using BloodDonorApp.Infrastructure.Query;
using BloodDonorApp.Infrastructure.Query.Helpers;
using BloodDonorApp.Infrastructure.Query.Predicates;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.Infrastructure.EF
{
    public class EFQuery<TEntity> : QueryBase<TEntity> where TEntity : class, IEntity, new()
    {
        protected DbContext Context => ((EFUnitOfWork)Factory.GetUnitOfWorkInstance()).Context;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EntityFrameworkQuery{TResult}" /> class.
        /// </summary>
        public EFQuery(IUnitOfWorkFactory factory) : base(factory) { }

        public override async Task<QueryResult<TEntity>> ExecuteAsync()
        {

            QueryResult<TEntity> result;
            var sql = new StringBuilder().Append($"{SqlConstants.SelectFromClause}[{typeof(TEntity).Name}]");

            if (Predicate != null)
            {
                var predicateResult = Predicate is CompositePredicate composite ?
                                            composite.BuildCompositePredicate() :
                                            (Predicate as SimplePredicate).BuildSimplePredicate();

                sql.Append($"{SqlConstants.WhereClause}{predicateResult}");
            }

            var itemsCount = Context.Set<TEntity>().SqlQuery(sql.ToString()).Count();

            if (!string.IsNullOrWhiteSpace(SortAccordingTo))
            {
                sql.Append(SqlConstants.OrderByClause + SortAccordingTo + (UseAscendingOrder ? SqlConstants.Ascending : SqlConstants.Descending));
            }

            if (DesiredPage > 0)
            {
                var items = (await Context.Set<TEntity>().SqlQuery(sql.ToString()).ToListAsync()).Skip((DesiredPage.Value - 1) * PageSize).Take(PageSize).ToList();
                result = new QueryResult<TEntity>(items, itemsCount, PageSize, DesiredPage);
            }
            else
            {
                List<TEntity> items = await Context.Set<TEntity>().SqlQuery(sql.ToString()).ToListAsync();
                result = new QueryResult<TEntity>(items, itemsCount);
            }
            return result;
            /*
            IQueryable<TEntity> queryable = Context.Set<TEntity>();

            if (string.IsNullOrWhiteSpace(SortAccordingTo) && DesiredPage.HasValue)
            {
                // Sorting must always take place when paging is required
                SortAccordingTo = nameof(IEntity.Id);
                UseAscendingOrder = true;
            }
            if (SortAccordingTo != null)
            {
                queryable = UseSortCriteria(queryable);
            }
            if (Predicate != null)
            {
                queryable = UseFilterCriteria(queryable);
            }
            var itemsCount = queryable.Count();
            if (DesiredPage.HasValue)
            {
                queryable = queryable.Skip(PageSize * (DesiredPage.Value - 1)).Take(PageSize);
            }
            var items = await queryable.ToListAsync();
            return new QueryResult<TEntity>(items, itemsCount, PageSize, DesiredPage);*/
        }
    }
}
