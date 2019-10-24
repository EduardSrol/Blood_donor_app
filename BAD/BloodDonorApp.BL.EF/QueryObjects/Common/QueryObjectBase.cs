using AutoMapper;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.Infrastructure.Data;
using BloodDonorApp.Infrastructure.Query;
using System;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.QueryObjects.Common
{
    public abstract class QueryObjectBase<TDto, TEntity, TFilter, TQuery>
        where TFilter : FilterDtoBase
        where TQuery : IQuery<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IMapper mapper;

        protected readonly IQuery<TEntity> Query;

        protected QueryObjectBase(IMapper mapper, TQuery query)
        {
            this.mapper = mapper;
            this.Query = query;
        }

        protected abstract IQuery<TEntity> ApplyWhereClause(IQuery<TEntity> query, TFilter filter);

        public virtual async Task<QueryResultDto<TDto, TFilter>> ExecuteQuery(TFilter filter)
        {
            // TODO...

            throw new NotImplementedException();
        }
    }
}
