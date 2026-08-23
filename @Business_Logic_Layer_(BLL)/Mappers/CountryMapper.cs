using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
namespace DVLD.BLL.Mappers
{
    /// <summary>
    /// Provides mapping methods between Country entities and Data Transfer Objects (DTOs).
    /// </summary>
    internal static class CountryMapper
    {
        /// <summary>
        /// Maps a list of Country entities into an OperationResults wrapper containing CountryReadDTO objects.
        /// </summary>
        /// <param name="data">The list of Country entity records.</param>
        /// <returns>An <see cref="OperationResults{CountryReadDTO}"/> with mapped data or a failure result.</returns>
        public static OperationResults<CountryReadDTO> MapToOperationResult(List<DVLD.DAL.Entities.Country> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<CountryReadDTO>.Failure(ErrorCode.NotFound, "There is no country data found.");
            }

            return OperationResults<CountryReadDTO>.Success(MapToReadDTOs(data), "Countries Data Retrieved Successfully.");
        }

        /// <summary>
        /// Maps a single Country entity to a CountryReadDTO.
        /// </summary>
        /// <param name="entity">The Country entity to map.</param>
        /// <returns>A new instance of <see cref="CountryReadDTO"/> populated with entity data.</returns>
        public static CountryReadDTO MapToReadDTO(Country entity)
        {
            //if (entity == null) return null;

            return new CountryReadDTO()
            {
                CountryID = entity.CountryID,
                CountryName = entity.CountryName
            };
        }

        /// <summary>
        /// Maps a collection of Country entities to a list of CountryReadDTO objects.
        /// </summary>
        /// <param name="entitiesList">The collection of Country entities.</param>
        /// <returns>A list of mapped <see cref="CountryReadDTO"/> instances.</returns>
        public static List<CountryReadDTO> MapToReadDTOs(List<Country> entitiesList)
        {
            var results = new List<CountryReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        /// <summary>
        /// Maps a CountryUpdateDTO to a Country entity for update operations.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated country details.</param>
        /// <returns>A new <see cref="Country"/> entity instance.</returns>
        public static Country MapToEntity(CountryUpdateDTO dto)
        {
            //if (dto == null) return null;

            return new Country()
            {
                CountryID = dto.CountryID,
                CountryName = dto.CountryName
            };
        }

        /// <summary>
        /// Maps a CountryAddDTO to a Country entity for creation operations.
        /// </summary>
        /// <param name="dto">The data transfer object containing new country details.</param>
        /// <returns>A new <see cref="Country"/> entity instance.</returns>
        public static Country MapToEntity(CountryAddDTO dto)
        {
            //if (dto == null) return null;

            return new Country()
            {
                CountryName = dto.CountryName
            };
        }
    }
}