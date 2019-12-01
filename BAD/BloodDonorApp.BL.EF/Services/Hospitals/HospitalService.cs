using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.QueryObjects.Common;
using BloodDonorApp.BL.EF.Services.Common;
using BloodDonorApp.BL.EF.Services.Hospitals;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Services.Hospitals
{
    public class HospitalService : CrudQueryServiceBase<Hospital, HospitalDto, HospitalFilterDto>, IHospitalService
    {
        public HospitalService(IMapper mapper, IRepository<Hospital> hospitalRepository, QueryObjectBase<HospitalDto, Hospital, HospitalFilterDto, IQuery<Hospital>> hospitalListQuery)
            : base(mapper, hospitalRepository, hospitalListQuery) { }

        public async Task<HospitalDto[]> GetHospitalsByCity(string city)
        {
            var queryResult = await Query.ExecuteQuery(new HospitalFilterDto() { City = city });
            return queryResult.Items.ToArray();
        }

        public async Task<HospitalDto[]> GetHospitalsByName(string name)
        {
            var queryResult = await Query.ExecuteQuery(new HospitalFilterDto() { Name = name });
            return queryResult.Items.ToArray();
        }

    }
}
