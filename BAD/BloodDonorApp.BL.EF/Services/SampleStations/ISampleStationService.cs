using System;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;

namespace BloodDonorApp.BL.EF.Services.SampleStations
{
    public interface ISampleStationService
    {

        /// <summary>
        /// Gets sample stations by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>sample stations by city</returns>
        Task<SampleStationDto[]> GetSampleStationsByCity(string city);

        /// <summary>
        /// Gets sample stations by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>sample stations by name</returns>
        Task<SampleStationDto[]> GetSampleStationsByName(string name);

        /// <summary>
        /// Gets DTO representing the entity according to ID
        /// </summary>
        /// <param name="entityId">entity ID</param>
        /// <returns>The DTO representing the entity</returns>
        Task<SampleStationDto> GetByIdAsync(Guid entityId);

        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Guid Insert(SampleStationDto entityDto);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Task Update(SampleStationDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Gets all DTOs (for given type)
        /// </summary>
        /// <returns>all available dtos (for given type)</returns>
        Task<QueryResultDto<SampleStationDto, SampleStationFilterDto>> ListAllAsync();

        Task<QueryResultDto<SampleStationDto, SampleStationFilterDto>> ListSampleStationsAsync(SampleStationFilterDto filter);

        Guid CreateSampleStation(SampleStationDto model);

    }
}
