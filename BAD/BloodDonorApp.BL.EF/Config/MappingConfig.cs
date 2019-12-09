using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.Infrastructure.Query;

namespace BloodDonorApp.BL.EF.Config
{
    public class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Admin, AdminDto>().ReverseMap();
            config.CreateMap<CommonUser, CommonUserRegistrationDto>().ReverseMap();
            config.CreateMap<CommonUser, CommonUserDto>()
                .ForMember(cuDto => cuDto.FullName, opts => opts.ResolveUsing(commonUser =>
                {
                    var fullName = commonUser.FirstName;
                    if (!string.IsNullOrWhiteSpace(commonUser.MiddleName))
                    {
                        fullName += " " + commonUser.MiddleName;
                    }

                    return fullName + " " + commonUser.LastName;
                }))
                .ForMember(cuDto => cuDto.FullBN, opts => opts.MapFrom(
                commonUser => commonUser.PrefixBN + "/" + commonUser.SufixBN))
                .ReverseMap();
            config.CreateMap<CommonUser, SessionUser>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).ReverseMap();

            config.CreateMap<CommonUserEditProfileExtendedDto, CommonUser>();
            config.CreateMap<CommonUser, CommonUserEditProfileExtendedDto>();

            config.CreateMap<BloodDonation, BloodDonationDto>().ReverseMap();
            config.CreateMap<Hospital, HospitalDto>().ReverseMap();
            config.CreateMap<SampleStation, SampleStationDto>().ReverseMap();
            config.CreateMap<CommonUser, ApplicantShortInfoDto>().ReverseMap();


            config.CreateMap<QueryResult<Admin>, QueryResultDto<AdminDto, AdminFilterDto>>();
            config.CreateMap<QueryResult<CommonUser>, QueryResultDto<CommonUserDto, CommonUserFilterDto>>();
            config.CreateMap<QueryResult<BloodDonation>, QueryResultDto<BloodDonationDto, BloodDonationFilterDto>>();
            config.CreateMap<QueryResult<Hospital>, QueryResultDto<HospitalDto, HospitalFilterDto>>();
            config.CreateMap<QueryResult<SampleStation>, QueryResultDto<SampleStationDto, SampleStationFilterDto>>();
        }
    }
}
