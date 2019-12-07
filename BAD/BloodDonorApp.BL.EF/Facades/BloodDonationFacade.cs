using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.BloodDonations;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades
{
    public class BloodDonationFacade : FacadeBase
    {
        private readonly IBloodDonationService bloodDonationService;

        public BloodDonationFacade(IUnitOfWorkFactory unitOfWorkFactory, IBloodDonationService bloodDonationService) : base(unitOfWorkFactory)
        {
            this.bloodDonationService = bloodDonationService;
        }

        public async Task<QueryResultDto<BloodDonationDto, BloodDonationFilterDto>> GetBloodDonations(BloodDonationFilterDto filter)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await bloodDonationService.ListBloodDonationsAsync(filter);
            }
        }

        public async Task<BloodDonationDto> GetBloodDonationByIdAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var bloodDonation = await bloodDonationService.GetByIdAsync(id);
                return bloodDonation;
            }
        }

        public async Task<Guid> CreateBloodDonation(BloodDonationDto model)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var id = bloodDonationService.CreateBloodDonation(model);
                await uow.CommitAsync();
                return id;
            }
        }
    }
}
