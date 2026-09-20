using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.ApplicationMapper;

namespace DVLD.BLL.Services
{
    /// <summary>
    /// Provides business logic services and operations for managing application entities.
    /// </summary>
    public class ApplicationService
    {
        #region Constructors

        private readonly IApplicationRepository _applicationRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class with the default ADO.NET repository.
        /// </summary>
        public ApplicationService()
        {
            _applicationRepo = new ApplicationRepositoryADO();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class with a specified data repository.
        /// </summary>
        /// <param name="applicationRepo">The repository instance used for data access operations.</param>
        public ApplicationService(IApplicationRepository applicationRepo)
        {
            _applicationRepo = applicationRepo;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Asynchronously retrieves all application records from the data store.
        /// </summary>
        /// <returns>
        /// An <see cref="OperationResults{ApplicationReadDTO}"/> containing the list of retrieved applications on success, 
        /// or error details if no data is found.
        /// </returns>
        public async Task<OperationResults<ApplicationReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _applicationRepo.GetAllAsync());
        }

        /// <summary>
        /// Asynchronously determines whether an application exists with the specified application ID.
        /// </summary>
        /// <param name="id">The unique identifier of the application to check.</param>
        /// <returns>
        /// <see langword="true"/> if the application exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _applicationRepo.ExistsAsync(id);
        }

        /// <summary>
        /// Asynchronously adds a new application record.
        /// </summary>
        /// <param name="dto">The data transfer object containing the new application details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Int32}"/> containing the generated Application ID upon success, 
        /// or a failure result if insertion fails.
        /// </returns>
        public async Task<OperationResult<int>> AddAsync(ApplicationAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Application data cannot be null.");
            }
            int addResult = await _applicationRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Application added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add application.");
        }

        /// <summary>
        /// Asynchronously retrieves the total count of application records in the data store.
        /// </summary>
        /// <returns>The total number of registered applications.</returns>
        public async Task<int> GetCountAsync()
        {
            return await _applicationRepo.CountAsync();
        }

        /// <summary>
        /// Asynchronously retrieves an application record by its unique ID.
        /// </summary>
        /// <param name="applicationId">The unique identifier of the application.</param>
        /// <returns>
        /// An <see cref="OperationResult{ApplicationReadDTO}"/> containing the application data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<ApplicationReadDTO>> GetByIdAsync(int applicationId)
        {
            var data = await _applicationRepo.FindAsync(applicationId);
            if (data == null || data.ApplicationID <= 0)
            {
                return OperationResult<ApplicationReadDTO>.Failure(ErrorCode.NotFound, "No Application Data Found.");
            }

            return OperationResult<ApplicationReadDTO>.Success(MapToReadDTO(data), "Application Data Retrieved Successfully.");
        }

        /// <summary>
        /// Asynchronously deletes an application record by its unique ID after verifying existence.
        /// </summary>
        /// <param name="id">The unique identifier of the application to delete.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the deletion succeeded, 
        /// or an error describing why deletion failed.
        /// </returns>
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _applicationRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Application not found.");
            }

            bool isDeleted = await _applicationRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete this application because it is linked to other records.");
            }

            return OperationResult<bool>.Success(true, "Application deleted successfully.");
        }

        /// <summary>
        /// Asynchronously updates an existing application record after verifying existence.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated application details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the update operation succeeded or failed.
        /// </returns>
        public async Task<OperationResult<bool>> UpdateAsync(ApplicationUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Application data cannot be null.");
            }

            var existingApplication = await _applicationRepo.FindAsync(dto.ApplicationID);
            if (existingApplication == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Application with ID {dto.ApplicationID} is not found.");
            }

            var entity = MapToEntity(dto);
            entity.CreatedByUserID = existingApplication.CreatedByUserID;

            bool isUpdated = await _applicationRepo.UpdateAsync(entity);
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update application.");
            }

            return OperationResult<bool>.Success(true, "Application updated successfully.");
        }

        #endregion
    }
}