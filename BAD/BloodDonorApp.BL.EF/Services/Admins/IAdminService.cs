using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.BL.EF.DTO.Filters;

namespace BloodDonorApp.BL.EF.Services.Admins
{
    public interface IAdminService
    {
        Task<AdminDto[]> GetAdminByAdminTypes(AdminType[] adminTypes);

        Task<AdminDto> GetAdminByUserName(string userName);

        /// <summary>
        /// Checks if username already exists
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if username doesn't already exist</returns>
        Task<bool> IsUsernameAvailable(string userName);

        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Guid Insert(AdminDto entityDto);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Task Update(AdminDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Gets all DTOs (for given type)
        /// </summary>
        /// <returns>all available dtos (for given type)</returns>
        Task<QueryResultDto<AdminDto, AdminFilterDto>> ListAllAsync();

        Guid RegisterAdminAsync(AdminDto model);
        Task<bool> AuthorizeAdminAsync(string username, string password);
    }
}
