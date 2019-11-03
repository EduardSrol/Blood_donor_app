using System;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.Common
{
    public abstract class CrudQueryServiceBase<TEntity, TDto, TFilterDto> : ServiceBase
        where TFilterDto : FilterDtoBase, new()
        where TEntity : class, IEntity, new()
        where TDto : DtoBase
    {
        protected readonly IRepository<TEntity> Repository;

        protected readonly QueryObjectBase<TDto, TEntity, TFilterDto, IQuery<TEntity>> Query;

        protected CrudQueryServiceBase(IMapper mapper, IRepository<TEntity> repository, QueryObjectBase<TDto, TEntity, TFilterDto, IQuery<TEntity>> query) : base(mapper)
        {
            this.Query = query;
            this.Repository = repository;
        }

        public virtual async Task<TDto> GetByIdAsync(Guid entityId)
        {
            TEntity entity = await Repository.GetByIdAsync(entityId);

            return entity != null ? Mapper.Map<TDto>(entity) : null;
        }

        public virtual Guid Insert(TDto entityDto)
        {
            var entity = Mapper.Map<TEntity>(entityDto);
            Repository.Insert(entity);
            return entity.Id;
        }

        public virtual async Task Update(TDto entityDto)
        {
            var entity = await Repository.GetByIdAsync(entityDto.Id);
            Mapper.Map(entityDto, entity);
            Repository.Update(entity);
        }

        public virtual void Delete(Guid entityId)
        {
            Repository.Delete(entityId);
        }

        public virtual async Task<QueryResultDto<TDto, TFilterDto>> ListAllAsync()
        {
            return await Query.ExecuteQuery(new TFilterDto());
        }
    }
}
