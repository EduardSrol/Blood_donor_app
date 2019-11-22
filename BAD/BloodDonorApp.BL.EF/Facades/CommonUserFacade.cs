﻿using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.CommonUsers;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Facades
{
    public class CommonUserFacade : FacadeBase
    {
        private readonly ICommonUserService commonUserService;

        public CommonUserFacade(IUnitOfWorkFactory unitOfWorkFactory, ICommonUserService commonUserService) : base(unitOfWorkFactory)
        {
            this.commonUserService = commonUserService;
        }

        public async Task<CommonUserDto> GetCommonUserByUun(int uun)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUserByUun(uun);
            }
        }

        public async Task<CommonUserDto> GetCommonUserByUserName(string userName)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUserByUserName(userName);
            }
        }

        public async Task<CommonUserDto[]> GetCommonUserByFullName(string fullName)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUserByFullName(fullName);
            }
        }

        public async Task<CommonUserDto> GetCommonUserByEmail(string email)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUserByEmail(email);
            }
        }

        public async Task<CommonUserDto> GetCommonUserByPhone(string phone)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUserByPhone(phone);
            }
        }

        public async Task<CommonUserDto[]> GetCommonUsersByBloodTypes(BloodType[] bloodTypes)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUsersByBloodTypes(bloodTypes);
            }
        }

        public async Task<CommonUserDto[]> GetCommonUsersByUserTypes(CommonUserType[] userTypes)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.GetCommonUsersByUserTypes(userTypes);
            }
        }

        public async Task<QueryResultDto<CommonUserDto, CommonUserFilterDto>> GetCommonUsers(CommonUserFilterDto filter)
        {
            using (UnitOfWorkFactory.Create())
            {
                return await commonUserService.ListCommonUsersAsync(filter);
            }
        }
    }
}
