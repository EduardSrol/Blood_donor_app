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

        public async Task<CommonUserDto> GetCommonUserByUserNameAsync(string userName)
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

        public async Task<CommonUserDto[]> GetCommonUsersByUserTypes(UserType[] userTypes)
        {
            var queryResult = await Query.ExecuteQuery(new CommonUserFilterDto() { UserTypes = userTypes });
            return queryResult.Items.ToArray();
        }

        public async Task<QueryResultDto<CommonUserDto, CommonUserFilterDto>> ListCommonUsersAsync(CommonUserFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
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

        public bool AuthorizeUser(string username, string password, out SessionUser user)
        {
            var resultUser = GetCommonUserByUserName(username);
            if (resultUser == null || !Utils.VerifyHashedPassword(resultUser.PasswordHash, resultUser.PasswordSalt, password))
            {
                user = null;
                return false;
            }
            user = Mapper.Map<CommonUser, SessionUser>(resultUser);
            return true;
        }

        public CommonUser GetCommonUserByUserName(string userName)
        {
            return Repository.Where(u => u.UserName.Equals(userName) && !u.IsDeleted).FirstOrDefault();
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

        public async Task<ApplicantShortInfoDto> GetApplicantByIdAsync(Guid id)
        {
            var user = await Repository.GetByIdAsync(id);
            var model = Mapper.Map<ApplicantShortInfoDto>(user);
            return model;
        }
    }
}
