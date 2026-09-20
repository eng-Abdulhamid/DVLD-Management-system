using System.Collections.Generic;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    /// <summary>
    /// Provides mapping methods between ApplicationType entities and Data Transfer Objects (DTOs).
    /// </summary>
    internal static class ApplicationTypeMapper
    {
        /// <summary>
        /// Maps a list of ApplicationType entities into an OperationResults wrapper containing ApplicationTypeReadDTO objects.
        /// </summary>
        public static OperationResults<ApplicationTypeReadDTO> MapToOperationResult(List<ApplicationType> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<ApplicationTypeReadDTO>.Failure(ErrorCode.NotFound, "There is no application type data found.");
            }

            return OperationResults<ApplicationTypeReadDTO>.Success(MapToReadDTOs(data), "Application types retrieved successfully.");
        }

        /// <summary>
        /// Maps a single ApplicationType entity to an ApplicationTypeReadDTO.
        /// </summary>
        public static ApplicationTypeReadDTO MapToReadDTO(ApplicationType entity)
        {
            if (entity == null) return null!;

            return new ApplicationTypeReadDTO
            {
                ApplicationTypeID = entity.ApplicationTypeID,
                ApplicationTypeTitle = entity.ApplicationTypeTitle,
                ApplicationFees = entity.ApplicationFees
            };
        }

        /// <summary>
        /// Maps a collection of ApplicationType entities to a list of ApplicationTypeReadDTO objects.
        /// </summary>
        public static List<ApplicationTypeReadDTO> MapToReadDTOs(List<ApplicationType> entitiesList)
        {
            var results = new List<ApplicationTypeReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        /// <summary>
        /// Maps an ApplicationTypeUpdateDTO to an ApplicationType entity for update operations.
        /// </summary>
        public static ApplicationType MapToEntity(ApplicationTypeUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new ApplicationType
            {
                ApplicationTypeID = dto.ApplicationTypeID,
                ApplicationTypeTitle = dto.ApplicationTypeTitle,
                ApplicationFees = dto.ApplicationFees
            };
        }

        /// <summary>
        /// Maps an ApplicationTypeAddDTO to an ApplicationType entity for creation operations.
        /// </summary>
        public static ApplicationType MapToEntity(ApplicationTypeAddDTO dto)
        {
            if (dto == null) return null!;

            return new ApplicationType
            {
                ApplicationTypeTitle = dto.ApplicationTypeTitle,
                ApplicationFees = dto.ApplicationFees
            };
        }
    }
}