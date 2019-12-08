using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.Hospitals;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades
{
    public class HospitalFacade : FacadeBase
    {
        private readonly IHospitalService hospitalService;

        public HospitalFacade(IUnitOfWorkFactory unitOfWorkFactory, IHospitalService hospitalService) : base(unitOfWorkFactory)
        {
            this.hospitalService = hospitalService;
        }

        public async Task<QueryResultDto<HospitalDto, HospitalFilterDto>> GetHospitals(HospitalFilterDto filter)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await hospitalService.ListHospitalsAsync(filter);
            }
        }

        public async Task<HospitalDto> GetHospitalByIdAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var hospital = await hospitalService.GetByIdAsync(id);
                return hospital;
            }
        }

        public async Task<Guid> CreateHospital(HospitalDto model)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                if (await hospitalService.IsSampleStationUnique(model, true, true))
                {
                    var id = hospitalService.CreateHospital(model);
                    await uow.CommitAsync();
                    return id;
                }
                throw new ArgumentException("There is already registered hospital with this name and address.");
            }
        }
    }
}
