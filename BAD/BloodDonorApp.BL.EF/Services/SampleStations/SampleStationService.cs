using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.SampleStations
{
    public class SampleStationService : CrudQueryServiceBase<SampleStation, SampleStationDto, SampleStationFilterDto>, ISampleStationService
    {
        public SampleStationService(IMapper mapper, IRepository<SampleStation> sampleStationRepository, QueryObjectBase<SampleStationDto, SampleStation, SampleStationFilterDto, IQuery<SampleStation>> sampleStationListQuery)
            : base(mapper, sampleStationRepository, sampleStationListQuery) { }

        public async Task<SampleStationDto[]> GetSampleStationsByCity(string city)
        {
            var queryResult = await Query.ExecuteQuery(new SampleStationFilterDto() { City = city});
            return queryResult.Items.ToArray();
        }

        public async Task<SampleStationDto[]> GetSampleStationsByName(string name)
        {
            var queryResult = await Query.ExecuteQuery(new SampleStationFilterDto() { Name = name});
            return queryResult.Items.ToArray();
        }

        public async Task<QueryResultDto<SampleStationDto, SampleStationFilterDto>> ListSampleStationsAsync(SampleStationFilterDto filter) {
            return await Query.ExecuteQuery(filter);
        }


        public Guid CreateSampleStation(SampleStationDto model)
        {
            var sampleStation = Mapper.Map<SampleStation>(model);
            Repository.Insert(sampleStation);
            return sampleStation.Id;
        }
    }

}