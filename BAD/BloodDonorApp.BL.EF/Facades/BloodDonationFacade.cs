using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.BloodDonations;
using BloodDonorApp.BL.EF.Services.CommonUsers;
using BloodDonorApp.BL.EF.Services.SampleStations;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades
{
    public class BloodDonationFacade : FacadeBase
    {
        private readonly IBloodDonationService bloodDonationService;
        private readonly ICommonUserService commonUserService;
        private readonly ISampleStationService sampleStationService;

        public BloodDonationFacade(IUnitOfWorkFactory unitOfWorkFactory, IBloodDonationService bloodDonationService,
            ICommonUserService commonUserService, ISampleStationService sampleStationService) : base(unitOfWorkFactory)
        {
            this.bloodDonationService = bloodDonationService;
            this.commonUserService = commonUserService;
            this.sampleStationService = sampleStationService;
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
                var donor = await commonUserService.GetCommonUserByIdAsync(bloodDonation.DonorId);
                bloodDonation.DonorName = $"{donor.FirstName} {donor.LastName}";
                var applicant = await commonUserService.GetCommonUserByIdAsync(bloodDonation.ApplicantId);
                bloodDonation.ApplicantName = $"{applicant.FirstName} {applicant.LastName}";
                var station = await sampleStationService.GetByIdAsync(bloodDonation.SampleStationId);
                bloodDonation.SampleStationName = $"{station.Name}";
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
