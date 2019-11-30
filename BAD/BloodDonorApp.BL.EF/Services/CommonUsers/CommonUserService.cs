using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BloodDonorApp.BL.EF.Services.CommonUsers
{
    public class CommonUserService : CrudQueryServiceBase<CommonUser, CommonUserDto, CommonUserFilterDto>, ICommonUserService
    {
        public CommonUserService(IMapper mapper, IRepository<CommonUser> commonUserRepository, QueryObjectBase<CommonUserDto, CommonUser, CommonUserFilterDto, IQuery<CommonUser>> commonUserListQuery)
            : base(mapper, commonUserRepository, commonUserListQuery) { }

        public async Task<CommonUserDto> GetCommonUserByUun(int uun)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { UUN = uun });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<CommonUserDto> GetCommonUserByUserName(string userName)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { Username = userName });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<CommonUserDto[]> GetCommonUserByFullName(string fullName)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { FullName = fullName });
            return queryResult.Items.ToArray();
        }

        public async Task<CommonUserDto> GetCommonUserByEmail(string email)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { Email = email });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<CommonUserDto> GetCommonUserByPhone(string phone)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { Phone = phone });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<CommonUserDto[]> GetCommonUsersByBloodTypes(BloodType[] bloodTypes)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { BloodTypes = bloodTypes });
            return queryResult.Items.ToArray();
        }

        public async Task<CommonUserDto[]> GetCommonUsersByUserTypes(CommonUserType[] userTypes)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { CommonUserTypes = userTypes });
            return queryResult.Items.ToArray();
        }

        public async Task<QueryResultDto<CommonUserDto, CommonUserFilterDto>> ListCommonUsersAsync(CommonUserFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
        }

        public async Task<CommonUserEditProfileExtendedDto> GetCommonUserEditExtendedDto(Guid id)
        {
            var user = await Repository.GetByIdAsync(id);
            var model = Mapper.Map<CommonUserEditProfileExtendedDto>(user);
            return model;
        }

        public async Task<CommonUserDto> GetCommonUserDtoByIdAsync(Guid id)
        {
            var user = await Repository.GetByIdAsync(id);
            var model = Mapper.Map<CommonUserDto>(user);
            return model;
        }
        public async Task<CommonUser> GetCommonUserByIdAsync(Guid id)
        {
            return await Repository.GetByIdAsync(id);
        }


        public async Task UpdateCommonUserAsync(CommonUser user)
        {
            await Repository.UpdateAsync(user);
        }

        public Guid RegisterUserAsync(CommonUserRegistrationDTO model)
        {
            var user = Mapper.Map<CommonUser>(model);

            var password = Utils.GenerateHash(model.Password);
            user.PasswordHash = password.Item1;
            user.PasswordSalt = password.Item2;

            Repository.Insert(user);
            return user.Id;
        }

        public async Task<bool> AuthorizeUserAsync(string username, string password)
        {
            var user = await GetCommonUserByUserName(username);
            var isValid = user != null && Utils.VerifyHashedPassword(user.PasswordHash, user.PasswordSalt, password);
            return isValid;
        }

        public async Task<bool> IsUsernameAvailable(string userName)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { Username = userName });
            return queryResult.Items.SingleOrDefault() == null;
        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { Email = email });
            return queryResult.Items.SingleOrDefault() == null;
        }

        public void Update (CommonUserEditProfileExtendedDto extendedProfileDto)
        {
            var user = Mapper.Map<CommonUser>(extendedProfileDto);
            Repository.Update(user);

        }
    }
}
