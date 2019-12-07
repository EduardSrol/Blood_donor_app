using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.BloodDonations
{
    public class BloodDonationService : CrudQueryServiceBase<BloodDonation, BloodDonationDto, BloodDonationFilterDto>, IBloodDonationService
    {
        public BloodDonationService(IMapper mapper, IRepository<BloodDonation> bloodDonationRepository, QueryObjectBase<BloodDonationDto, BloodDonation, BloodDonationFilterDto, IQuery<BloodDonation>> bloodDonationListQuery)
            : base(mapper, bloodDonationRepository, bloodDonationListQuery) { }

        public async Task<BloodDonationDto[]> GetBloodDonationsByBloodTypesAsync(BloodType[] bloodTypes)
        {
            var queryResult = await Query.ExecuteQuery(new BloodDonationFilterDto {BloodTypes = bloodTypes});
            return queryResult.Items.ToArray();
        }

        public async Task<BloodDonationDto[]> GetBloodDonationsByDonorId(Guid donorId)
        {
            var queryResult = await Query.ExecuteQuery(new BloodDonationFilterDto { DonorId = donorId });
            return queryResult.Items.ToArray();
        }

        public async Task<BloodDonationDto[]> GetBloodDonationsByApplicantId(Guid applicantId)
        {
            var queryResult = await Query.ExecuteQuery(new BloodDonationFilterDto { ApplicantId = applicantId });
            return queryResult.Items.ToArray();
        }

        public async Task<BloodDonationDto[]> GetBloodDonationsBySampleStationId(Guid sampleStationId)
        {
            var queryResult = await Query.ExecuteQuery(new BloodDonationFilterDto { SampleStationId = sampleStationId});
            return queryResult.Items.ToArray();
        }

        public async Task<QueryResultDto<BloodDonationDto, BloodDonationFilterDto>> ListBloodDonationsAsync(BloodDonationFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
        }


        public Guid CreateBloodDonation(BloodDonationDto model)
        {
            var bloodDonation = Mapper.Map<BloodDonation>(model);
            Repository.Insert(bloodDonation);
            return bloodDonation.Id;
        }
    }
}
