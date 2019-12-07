using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.BL.EF.Services.CommonUsers
{
    public interface ICommonUserService
    {
        Task<QueryResultDto<CommonUserDto, CommonUserFilterDto>> ListCommonUsersAsync(CommonUserFilterDto filter);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="uun"></param>
        /// <returns></returns>
        Task<CommonUserDto> GetCommonUserByUun(int uun);

        Task<CommonUserDto> GetCommonUserByUserName(string userName);

        Task<CommonUserDto[]> GetCommonUserByFullName(string fullName);

        Task<CommonUserDto> GetCommonUserByEmail(string email);

        Task<CommonUserDto> GetCommonUserByPhone(string phone);

        Task<CommonUserDto[]> GetCommonUsersByBloodTypes(BloodType[] bloodTypes);

        Task<CommonUserDto[]> GetCommonUsersByUserTypes(UserType[] userTypes);

        Task<CommonUser> GetCommonUserByIdAsync(Guid id);

        Task<CommonUserDto> GetCommonUserDtoByIdAsync(Guid id);

        Task UpdateCommonUserAsync(CommonUser user);

        Guid RegisterUserAsync(CommonUserRegistrationDTO model);

        Task<bool> AuthorizeUserAsync(string username, string password);

        /// <summary>
        /// Checks if username already exists
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if username doesn't already exist</returns>
        Task<bool> IsUsernameAvailable(string userName);

        /// <summary>
        /// Checks if email already exists
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if email doesn't already exist</returns>
        Task<bool> IsEmailAvailable(string email);


        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Guid Insert(CommonUserDto entityDto);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Task Update(CommonUserDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Gets all DTOs (for given type)
        /// </summary>
        /// <returns>all available dtos (for given type)</returns>
        Task<QueryResultDto<CommonUserDto, CommonUserFilterDto>> ListAllAsync();

        Task<ApplicantShortInfoDto> GetApplicantByIdAsync(Guid id);
    }
}
