using System;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;

namespace BloodDonorApp.BL.EF.Services.Hospitals
{
    public interface IHospitalService
    {
        /// <summary>
        /// Gets hospitals by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>hospitals by city</returns>
        Task<HospitalDto[]> GetHospitalsByCity(string city);

        /// <summary>
        /// Gets hospitals by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>hospitals by name</returns>
        Task<HospitalDto[]> GetHospitalsByName(string name);

        /// <summary>
        /// Gets DTO representing the entity according to ID
        /// </summary>
        /// <param name="entityId">entity ID</param>
        /// <returns>The DTO representing the entity</returns>
        Task<HospitalDto> GetByIdAsync(Guid entityId);

        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Guid Insert(HospitalDto entityDto);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Task Update(HospitalDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Gets all DTOs (for given type)
        /// </summary>
        /// <returns>all available dtos (for given type)</returns>
        Task<QueryResultDto<HospitalDto, HospitalFilterDto>> ListAllAsync();

        Task<QueryResultDto<HospitalDto, HospitalFilterDto>> ListHospitalsAsync(HospitalFilterDto filter);

        Guid CreateHospital(HospitalDto model);

        Task<bool> IsHospitalUnique(HospitalDto model, bool checkAddress, bool checkName);

    }
}
