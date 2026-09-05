using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.DriverMapper;

namespace DVLD.BLL.Services
{
    /// <summary>
    /// Provides business logic services and operations for managing driver entities.
    /// </summary>
    public class DriverService
    {
        #region Constructors

        private readonly IDriverRepository _driverRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class with the default ADO.NET repository.
        /// </summary>
        public DriverService()
        {
            _driverRepo = new DriverRepositoryADO();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class with a specified data repository.
        /// </summary>
        /// <param name="driverRepo">The repository instance used for data access operations.</param>
        public DriverService(IDriverRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Asynchronously retrieves all driver records from the data store.
        /// </summary>
        /// <returns>
        /// An <see cref="OperationResults{DriverReadDTO}"/> containing the list of retrieved drivers on success, 
        /// or error details if no data is found.
        /// </returns>
        public async Task<OperationResults<DriverReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _driverRepo.GetAllAsync());
        }

        /// <summary>
        /// Asynchronously determines whether a driver exists with the specified driver ID.
        /// </summary>
        /// <param name="id">The unique identifier of the driver to check.</param>
        /// <returns>
        /// <see langword="true"/> if the driver exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _driverRepo.ExistsAsync(id);
        }

        /// <summary>
        /// Asynchronously adds a new driver record.
        /// </summary>
        /// <param name="dto">The data transfer object containing the new driver details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Int32}"/> containing the generated Driver ID upon success, 
        /// or a failure result if insertion fails.
        /// </returns>
        public async Task<OperationResult<int>> AddAsync(DriverAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Driver data cannot be null.");
            }

            int addResult = await _driverRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Driver added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add driver.");
        }

        /// <summary>
        /// Asynchronously retrieves the total count of driver records in the data store.
        /// </summary>
        /// <returns>The total number of registered drivers.</returns>
        public async Task<int> GetCountAsync()
        {
            return await _driverRepo.CountAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a driver record by their unique ID.
        /// </summary>
        /// <param name="driverId">The unique identifier of the driver.</param>
        /// <returns>
        /// An <see cref="OperationResult{DriverReadDTO}"/> containing the driver data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<DriverReadDTO>> GetByIdAsync(int driverId)
        {
            var data = await _driverRepo.FindAsync(driverId);
            if (data == null || data.DriverID <= 0)
            {
                return OperationResult<DriverReadDTO>.Failure(ErrorCode.NotFound, "No Driver Data Found.");
            }

            return OperationResult<DriverReadDTO>.Success(MapToReadDTO(data), "Driver Data Retrieved Successfully.");
        }

        /// <summary>
        /// Asynchronously deletes a driver record by their unique ID after verifying existence.
        /// </summary>
        /// <param name="id">The unique identifier of the driver to delete.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the deletion succeeded, 
        /// or an error describing why deletion failed.
        /// </returns>
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _driverRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Driver not found.");
            }

            bool isDeleted = await _driverRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete this driver because they may have linked licenses or records.");
            }

            return OperationResult<bool>.Success(true, "Driver deleted successfully.");
        }

        /// <summary>
        /// Asynchronously updates an existing driver record after verifying existence.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated driver details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the update operation succeeded or failed.
        /// </returns>
        public async Task<OperationResult<bool>> UpdateAsync(DriverUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Driver data cannot be null.");
            }

            if (!await _driverRepo.ExistsAsync(dto.DriverID))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Driver with ID {dto.DriverID} is not found.");
            }

            bool isUpdated = await _driverRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update driver.");
            }

            return OperationResult<bool>.Success(true, "Driver updated successfully.");
        }

        #endregion
    }
}