using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    /// <summary>
    /// Provides mapping methods between Driver entities and Data Transfer Objects (DTOs).
    /// </summary>
    internal static class DriverMapper
    {
        /// <summary>
        /// Maps a list of Driver entities into an OperationResults wrapper containing DriverReadDTO objects.
        /// </summary>
        public static OperationResults<DriverReadDTO> MapToOperationResult(List<Driver> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<DriverReadDTO>.Failure(ErrorCode.NotFound, "There is no Driver data found.");
            }

            return OperationResults<DriverReadDTO>.Success(MapToReadDTOs(data), "Drivers Data Retrieved Successfully.");
        }

        /// <summary>
        /// Maps a single Driver entity to a DriverReadDTO.
        /// </summary>
        public static DriverReadDTO MapToReadDTO(Driver entity)
        {
            if (entity == null) return null;

            return new DriverReadDTO
            {
                DriverID = entity.DriverID,
                PersonID = entity.PersonID,
                CreatedByUserID = entity.CreatedByUserID,
                CreatedDate = entity.CreatedDate
            };
        }

        /// <summary>
        /// Maps a collection of Driver entities to a list of DriverReadDTO objects.
        /// </summary>
        public static List<DriverReadDTO> MapToReadDTOs(List<Driver> entitiesList)
        {
            var results = new List<DriverReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        /// <summary>
        /// Maps a DriverUpdateDTO to a Driver entity for update operations.
        /// </summary>
        public static Driver MapToEntity(DriverUpdateDTO dto)
        {
            if (dto == null) return null;

            return new Driver
            {
                DriverID = dto.DriverID,
                PersonID = dto.PersonID,
                CreatedByUserID = dto.CreatedByUserID,
                CreatedDate = DateTime.Now
            };
        }

        /// <summary>
        /// Maps a DriverAddDTO to a Driver entity for creation operations.
        /// </summary>
        public static Driver MapToEntity(DriverAddDTO dto)
        {
            if (dto == null) return null;

            return new Driver
            {
                PersonID = dto.PersonID,
                CreatedByUserID = dto.CreatedByUserID,
                CreatedDate = DateTime.Now
            };
        }
    }
}