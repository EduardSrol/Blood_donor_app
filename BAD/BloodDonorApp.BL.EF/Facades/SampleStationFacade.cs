using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.SampleStations;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades
{
    public class SampleStationFacade : FacadeBase
    {
        private readonly ISampleStationService sampleStationService;

        public SampleStationFacade(IUnitOfWorkFactory unitOfWorkFactory, ISampleStationService sampleStationService) : base(unitOfWorkFactory)
        {
            this.sampleStationService = sampleStationService;
        }

        public async Task<QueryResultDto<SampleStationDto, SampleStationFilterDto>> GetSampleStations(SampleStationFilterDto filter)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await sampleStationService.ListSampleStationsAsync(filter);
            }
        }

        public async Task<SampleStationDto> GetSampleStationByIdAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var sampleStation = await sampleStationService.GetByIdAsync(id);
                return sampleStation;
            }
        }

        public async Task<Guid> CreateSampleStation(SampleStationDto model)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                if (await sampleStationService.IsSampleStationUnique(model, true, false))
                {
                    var id = sampleStationService.CreateSampleStation(model);
                    await uow.CommitAsync();
                    return id;
                }
                throw new ArgumentException("There is already registered sample station to this address.");
            }
        }
    }
}
