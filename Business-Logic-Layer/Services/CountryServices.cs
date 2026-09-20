using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using DVLD.DAL.Entities;
using static DVLD.BLL.Mappers.CountryMapper;

namespace DVLD.BLL.Services
{
    /// <summary>
    /// Provides business logic services and operations for managing country entities.
    /// </summary>
    public class CountryService
    {
        #region Constructors

        private readonly ICountryRepository _countryRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class with the default ADO.NET repository.
        /// </summary>
        public CountryService()
        {
            _countryRepo = new CountryRepositoryADO();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class with a specified data repository.
        /// </summary>
        /// <param name="countryRepo">The repository instance used for data access operations.</param>
        public CountryService(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Asynchronously retrieves all country records from the data store.
        /// </summary>
        /// <returns>
        /// An <see cref="OperationResults{CountryReadDTO}"/> containing the list of retrieved countries on success, 
        /// or error details if no data is found.
        /// </returns>
        public async Task<OperationResults<CountryReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _countryRepo.GetAllAsync());
        }

        /// <summary>
        /// Asynchronously determines whether a country exists with the specified country ID.
        /// </summary>
        /// <param name="id">The unique identifier of the country to check.</param>
        /// <returns>
        /// <see langword="true"/> if the country exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _countryRepo.ExistsAsync(id);
        }

        /// <summary>
        /// Asynchronously adds a new country record after validating that the country name is unique.
        /// </summary>
        /// <param name="dto">The data transfer object containing the new country details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Int32}"/> containing the generated Country ID upon success, 
        /// or a failure result if a conflict occurs or insertion fails.
        /// </returns>
        public async Task<OperationResult<int>> AddAsync(CountryAddDTO dto)
        {
            if (dto == null) return OperationResult<int>.Failure(ErrorCode.BadRequest);
            if (await _countryRepo.ExistsByNameAsync(dto.CountryName))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "Country with the same name already exists.");
            }

            int addResult = await _countryRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Country added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add country.");
        }

        /// <summary>
        /// Asynchronously retrieves the total count of country records in the data store.
        /// </summary>
        /// <returns>The total number of registered countries.</returns>
        public async Task<int> GetCountAsync()
        {
            return await _countryRepo.CountAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a country record by its unique ID.
        /// </summary>
        /// <param name="countryId">The unique identifier of the country.</param>
        /// <returns>
        /// An <see cref="OperationResult{CountryReadDTO}"/> containing the country data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<CountryReadDTO>> GetByIdAsync(int countryId)
        {
            var data = await _countryRepo.FindAsync(countryId);
            if (data == null || data.CountryID <= 0)
            {
                return OperationResult<CountryReadDTO>.Failure(ErrorCode.NotFound, "No Country Data Found.");
            }

            return OperationResult<CountryReadDTO>.Success(MapToReadDTO(data), "Country Data Retrieved Successfully.");
        }
        
        /// <summary>
        /// Asynchronously deletes a country record by its unique ID after verifying existence and database constraints.
        /// </summary>
        /// <param name="id">The unique identifier of the country to delete.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the deletion succeeded, 
        /// or an error describing why deletion failed (e.g., entity not found or referenced in other records).
        /// </returns>
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _countryRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Country not found.");
            }

            bool isDeleted = await _countryRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete this country because it is referenced in other records.");
            }

            return OperationResult<bool>.Success(true, "Country deleted successfully.");
        }

        /// <summary>
        /// Asynchronously updates an existing country record after verifying existence and checking for name uniqueness conflicts.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated country details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the update operation succeeded or failed.
        /// </returns>
        public async Task<OperationResult<bool>> UpdateAsync(CountryUpdateDTO dto)
        {
            Country? country = await _countryRepo.FindAsync(dto.CountryID);
            if (country == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Country with ID {dto.CountryID} is not found.");
            }

            if (!string.Equals(country.CountryName, dto.CountryName, StringComparison.OrdinalIgnoreCase))
            {
                if (await _countryRepo.ExistsByNameAsync(dto.CountryName))
                {
                    return OperationResult<bool>.Failure(ErrorCode.Conflict, "Country with exact same name already exists.");
                }
            }

            bool isUpdated = await _countryRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update country.");
            }

            return OperationResult<bool>.Success(true, "Country updated successfully.");
        }

        /// <summary>
        /// Asynchronously retrieves a country record by its name.
        /// </summary>
        /// <param name="countryName">The name of the country to search for.</param>
        /// <returns>
        /// An <see cref="OperationResult{CountryReadDTO}"/> containing the country data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<CountryReadDTO>> GetByNameAsync(string countryName)
        {
            var data = await _countryRepo.FindByNameAsync(countryName);
            if (data == null)
            {
                return OperationResult<CountryReadDTO>.Failure(ErrorCode.NotFound, "No Country Data Found.");
            }

            return OperationResult<CountryReadDTO>.Success(MapToReadDTO(data), "Country Data Retrieved Successfully.");
        }

        /// <summary>
        /// Asynchronously determines whether a country exists with the specified country name.
        /// </summary>
        /// <param name="countryName">The country name to check for existence.</param>
        /// <returns>
        /// <see langword="true"/> if a country with the given name exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsByNameAsync(string countryName)
        {
            return await _countryRepo.ExistsByNameAsync(countryName);
        }

        #endregion
    }
}