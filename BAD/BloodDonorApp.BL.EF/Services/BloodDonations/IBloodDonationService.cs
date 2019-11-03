using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.Services.BloodDonations
{
    public interface IBloodDonationService
    {
        /// <summary>
        /// Gets all blood donations with specific blood type
        /// </summary>
        /// <param name="bloodTypes">names of the categories</param>
        /// <returns>blood donations with specific blood type</returns>
        Task<BloodDonationDto[]> GetBloodDonationsByBloodTypeAsync(BloodType[] bloodTypes);

        /// <summary>
        /// Gets all blood donations by donor id
        /// </summary>
        /// <param name="donorId"></param>
        /// <returns>blood donation by donor id</returns>
        Task<BloodDonationDto[]> GetBloodDonationsByDonorId(Guid donorId);

        /// <summary>
        /// Gets all blood donations by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>blood donation by applicant id</returns>
        Task<BloodDonationDto[]> GetBloodDonationsByApplicantId(Guid applicantId);

        /// <summary>
        /// Gets all blood donations by sample station id
        /// </summary>
        /// <param name="sampleStationId"></param>
        /// <returns>blood donation by sample station id</returns>
        Task<BloodDonationDto[]> GetBloodDonationsBySampleStationId(Guid sampleStationId);

        /// <summary>
        /// Gets DTO representing the entity according to ID
        /// </summary>
        /// <param name="entityId">entity ID</param>
        /// <returns>The DTO representing the entity</returns>
        Task<BloodDonationDto> GetByIdAsync(Guid entityId);

        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Guid Insert(BloodDonationDto entityDto);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Task Update(BloodDonationDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);
    }
}
