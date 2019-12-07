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
                var hospital = await hospitalService.GetHospitalDtoByIdAsync(id);
                return hospital
                    ;
            }
        }
    }
}
