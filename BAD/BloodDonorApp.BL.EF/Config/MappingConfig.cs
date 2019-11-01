﻿using System;
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

            //neviem preco nejde
            config.CreateMap<CommonUser, CommonUserDto>().ForMember(cuDto => cuDto.FullName, opts => opts.ResolveUsing(commonUser =>
            {
                var fullName = commonUser.FirstName;
                if (commonUser.MiddleName != null)
                {
                    fullName += " " + commonUser.MiddleName;
                }

                return fullName + " " + commonUser.LastName;
            })).ReverseMap();

            config.CreateMap<BloodDonation, BloodDonationDto>().ReverseMap();
            config.CreateMap<Hospital, HospitalDto>().ReverseMap();
            config.CreateMap<SampleStation, SampleStationDto>().ReverseMap();

            config.CreateMap<QueryResult<Admin>, QueryResultDto<AdminDto, AdminFilterDto>>();
            config.CreateMap<QueryResult<CommonUser>, QueryResultDto<CommonUserDto, CommonUserFilterDto>>();
            config.CreateMap<QueryResult<BloodDonation>, QueryResultDto<BloodDonationDto, BloodDonationFilterDto>>();
            config.CreateMap<QueryResult<Hospital>, QueryResultDto<HospitalDto, HospitalFilterDto>>();
            config.CreateMap<QueryResult<SampleStation>, QueryResultDto<SampleStationDto, SampleStationFilterDto>>();
        }
    }
}
