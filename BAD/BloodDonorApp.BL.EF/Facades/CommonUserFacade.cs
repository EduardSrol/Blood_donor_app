using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades.Common;
using BloodDonorApp.BL.EF.Services.CommonUsers;
using BloodDonorApp.Infrastructure.UnitOfWork;
using System;
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
                return await commonUserService.GetCommonUserByUserNameAsync(userName);
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

        public async Task<CommonUserDto[]> GetCommonUsersByUserTypes(UserType[] userTypes)
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

        public async Task DeleteUserSoftAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var user = await commonUserService.GetCommonUserByIdAsync(id);
                user.IsDeleted = true;
                await commonUserService.UpdateCommonUserAsync(user);
                await uow.CommitAsync();
            }
        }

        public async Task<CommonUserDto> GetCommonUserByIdAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var user = await commonUserService.GetCommonUserDtoByIdAsync(id);
                return user;
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                //TODO toto sluzilo skor ako skuska na to ako zistit ci to vieme spravit, VIEME
                // jasne ze musime najskor deletnut vsetky veci ktore sa tykaju tohto usera az potom usera
                // ako napriklad vsetky donations kde figuruje ako applicantID apod. resp. spravit namiesto toho
                // tzv. soft-delete kde ho len oznacime za deleted a vo Views budes rendrovat len nonDeleted users
                commonUserService.Delete(id);
                await uow.CommitAsync();
            }
        }

        public async Task Update(CommonUserDto user)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                await commonUserService.Update(user);
            }
        }

        public async Task<bool> IsCommonUserDataForRegistrationUnique(CommonUserRegistrationDTO model)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var availableEmail = await commonUserService.IsEmailAvailable(model.Email);
                var availableUserName = await commonUserService.IsUsernameAvailable(model.Username);
                return availableEmail && availableUserName;
            }
        }

        public async Task<Guid> RegisterCustomer(CommonUserRegistrationDTO model)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var id = commonUserService.RegisterUserAsync(model);
                await uow.CommitAsync();
                return id;
            }
        }

        public bool Login(string username, string password, out SessionUser user)
        {
            using (UnitOfWorkFactory.Create())
            {
                return commonUserService.AuthorizeUser(username, password, out user);
            }
        }

        public async Task<ApplicantShortInfoDto> GetApplicantByIdAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var applicant = await commonUserService.GetApplicantByIdAsync(id);
                return applicant;
            }
        }

    }
}
