using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    /// <summary>
    /// Provides mapping methods between Application entities and Data Transfer Objects (DTOs).
    /// </summary>
    internal static class ApplicationMapper
    {
        /// <summary>
        /// Maps a list of Application entities into an OperationResults wrapper containing ApplicationReadDTO objects.
        /// </summary>
        /// <param name="data">The list of Application entity records.</param>
        /// <returns>An <see cref="OperationResults{ApplicationReadDTO}"/> with mapped data or a failure result.</returns>
        public static OperationResults<ApplicationReadDTO> MapToOperationResult(List<DVLD.DAL.Entities.Application> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<ApplicationReadDTO>.Failure(ErrorCode.NotFound, "There is no Application data found.");
            }

            return OperationResults<ApplicationReadDTO>.Success(MapToReadDTOs(data), "Applications Data Retrieved Successfully.");
        }

        /// <summary>
        /// Maps a single Application entity to an ApplicationReadDTO.
        /// </summary>
        /// <param name="entity">The Application entity to map.</param>
        /// <returns>A new instance of <see cref="ApplicationReadDTO"/> populated with entity data.</returns>
        public static ApplicationReadDTO MapToReadDTO(Application entity)
        {
            //if (entity == null) return null;

            return new ApplicationReadDTO()
            {
                ApplicationID = entity.ApplicationID,
                ApplicantPersonID = entity.ApplicantPersonID,
                ApplicationDate = entity.ApplicationDate,
                ApplicationTypeID = entity.ApplicationTypeID,
                ApplicationStatus = entity.ApplicationStatus,
                LastStatusDate = entity.LastStatusDate,
                PaidFees = entity.PaidFees,
                CreatedByUserID = entity.CreatedByUserID
            };
        }

        /// <summary>
        /// Maps a collection of Application entities to a list of ApplicationReadDTO objects.
        /// </summary>
        /// <param name="entitiesList">The collection of Application entities.</param>
        /// <returns>A list of mapped <see cref="ApplicationReadDTO"/> instances.</returns>
        public static List<ApplicationReadDTO> MapToReadDTOs(List<Application> entitiesList)
        {
            var results = new List<ApplicationReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        /// <summary>
        /// Maps an ApplicationUpdateDTO to an Application entity for update operations.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated application details.</param>
        /// <returns>A new <see cref="Application"/> entity instance.</returns>
        public static Application MapToEntity(ApplicationUpdateDTO dto)
        {
            //if (dto == null) return null;

            return new Application()
            {
                ApplicationID = dto.ApplicationID,
                ApplicantPersonID = dto.ApplicantPersonID,
                ApplicationDate = dto.ApplicationDate,
                ApplicationTypeID = dto.ApplicationTypeID,
                ApplicationStatus = dto.ApplicationStatus,
                LastStatusDate = dto.LastStatusDate,
                PaidFees = dto.PaidFees
            };
        }

        /// <summary>
        /// Maps an ApplicationAddDTO to an Application entity for creation operations.
        /// </summary>
        /// <param name="dto">The data transfer object containing new application details.</param>
        /// <returns>A new <see cref="Application"/> entity instance.</returns>
        public static Application MapToEntity(ApplicationAddDTO dto)
        {
            //if (dto == null) return null;

            return new Application()
            {
                ApplicantPersonID = dto.ApplicantPersonID,
                ApplicationDate = dto.ApplicationDate,
                ApplicationTypeID = dto.ApplicationTypeID,
                ApplicationStatus = dto.ApplicationStatus,
                LastStatusDate = dto.LastStatusDate,
                PaidFees = dto.PaidFees,
                CreatedByUserID = dto.CreatedByUserID
            };
        }
    }
}