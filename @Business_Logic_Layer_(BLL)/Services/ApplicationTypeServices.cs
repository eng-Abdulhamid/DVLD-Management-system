using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.ApplicationTypeMapper;

namespace DVLD.BLL.Services
{
    /// <summary>
    /// Provides business logic services and operations for managing application types.
    /// </summary>
    public class ApplicationTypeService
    {
        #region Constructors

        private readonly IApplicationTypeRepository _applicationTypeRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationTypeService"/> class with the default ADO.NET repository.
        /// </summary>
        public ApplicationTypeService()
        {
            _applicationTypeRepo = new ApplicationTypeRepositoryADO();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationTypeService"/> class with a specified data repository.
        /// </summary>
        /// <param name="applicationTypeRepo">The repository instance used for data access operations.</param>
        public ApplicationTypeService(IApplicationTypeRepository applicationTypeRepo)
        {
            _applicationTypeRepo = applicationTypeRepo;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Asynchronously retrieves all application type records from the data store.
        /// </summary>
        /// <returns>
        /// An <see cref="OperationResults{ApplicationTypeReadDTO}"/> containing the list of retrieved application types on success, 
        /// or error details if no data is found.
        /// </returns>
        public async Task<OperationResults<ApplicationTypeReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _applicationTypeRepo.GetAllAsync());
        }

        /// <summary>
        /// Asynchronously determines whether an application type exists with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the application type to check.</param>
        /// <returns>
        /// <see langword="true"/> if the application type exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _applicationTypeRepo.ExistsAsync(id);
        }

        /// <summary>
        /// Asynchronously adds a new application type record after validating that the title is unique.
        /// </summary>
        /// <param name="dto">The data transfer object containing the new application type details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Int32}"/> containing the generated ApplicationType ID upon success, 
        /// or a failure result if a conflict occurs or insertion fails.
        /// </returns>
        public async Task<OperationResult<int>> AddAsync(ApplicationTypeAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Application type data cannot be null.");
            }

            if (await _applicationTypeRepo.ExistsByTitleAsync(dto.ApplicationTypeTitle))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "Application type with the same title already exists.");
            }

            int addResult = await _applicationTypeRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Application type added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add application type.");
        }

        /// <summary>
        /// Asynchronously retrieves the total count of application types in the data store.
        /// </summary>
        /// <returns>The total number of registered application types.</returns>
        public async Task<int> GetCountAsync()
        {
            return await _applicationTypeRepo.CountAsync();
        }

        /// <summary>
        /// Asynchronously retrieves an application type record by its unique ID.
        /// </summary>
        /// <param name="applicationTypeId">The unique identifier of the application type.</param>
        /// <returns>
        /// An <see cref="OperationResult{ApplicationTypeReadDTO}"/> containing the application type data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<ApplicationTypeReadDTO>> GetByIdAsync(int applicationTypeId)
        {
            var data = await _applicationTypeRepo.FindAsync(applicationTypeId);
            if (data == null || data.ApplicationTypeID <= 0)
            {
                return OperationResult<ApplicationTypeReadDTO>.Failure(ErrorCode.NotFound, "No Application Type Data Found.");
            }

            return OperationResult<ApplicationTypeReadDTO>.Success(MapToReadDTO(data), "Application Type Data Retrieved Successfully.");
        }

        /// <summary>
        /// Asynchronously retrieves an application type record by its title.
        /// </summary>
        /// <param name="title">The title of the application type to search for.</param>
        /// <returns>
        /// An <see cref="OperationResult{ApplicationTypeReadDTO}"/> containing the application type data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<ApplicationTypeReadDTO>> GetByTitleAsync(string title)
        {
            var data = await _applicationTypeRepo.FindByTitleAsync(title);
            if (data == null)
            {
                return OperationResult<ApplicationTypeReadDTO>.Failure(ErrorCode.NotFound, "No Application Type Data Found.");
            }

            return OperationResult<ApplicationTypeReadDTO>.Success(MapToReadDTO(data), "Application Type Data Retrieved Successfully.");
        }

        /// <summary>
        /// Asynchronously determines whether an application type exists with the specified title.
        /// </summary>
        /// <param name="title">The title to check for existence.</param>
        /// <returns>
        /// <see langword="true"/> if an application type with the given title exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _applicationTypeRepo.ExistsByTitleAsync(title);
        }

        /// <summary>
        /// Asynchronously deletes an application type record by its unique ID after verifying existence and relational constraints.
        /// </summary>
        /// <param name="id">The unique identifier of the application type to delete.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the deletion succeeded, 
        /// or an error describing why deletion failed.
        /// </returns>
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _applicationTypeRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Application type not found.");
            }

            bool isDeleted = await _applicationTypeRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete this application type because it is referenced in applications.");
            }

            return OperationResult<bool>.Success(true, "Application type deleted successfully.");
        }

        /// <summary>
        /// Asynchronously updates an existing application type record after verifying existence and checking for title conflicts.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated application type details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the update operation succeeded or failed.
        /// </returns>
        public async Task<OperationResult<bool>> UpdateAsync(ApplicationTypeUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Application type data cannot be null.");
            }

            ApplicationType? existingType = await _applicationTypeRepo.FindAsync(dto.ApplicationTypeID);
            if (existingType == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Application type with ID {dto.ApplicationTypeID} is not found.");
            }

            if (!string.Equals(existingType.ApplicationTypeTitle, dto.ApplicationTypeTitle, StringComparison.OrdinalIgnoreCase))
            {
                if (await _applicationTypeRepo.ExistsByTitleAsync(dto.ApplicationTypeTitle))
                {
                    return OperationResult<bool>.Failure(ErrorCode.Conflict, "Application type with the same title already exists.");
                }
            }

            bool isUpdated = await _applicationTypeRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update application type.");
            }

            return OperationResult<bool>.Success(true, "Application type updated successfully.");
        }

        #endregion
    }
}