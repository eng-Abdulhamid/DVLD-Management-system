using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
using static DVLD.BLL.Mappers.PersonMapper;

namespace DVLD.BLL.Services
{
    /// <summary>
    /// Provides business logic services and operations for managing person entities.
    /// </summary>
    public class PersonService
    {
        #region Constructors

        private readonly IPersonRepository _personRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class with the default ADO.NET repository.
        /// </summary>
        public PersonService()
        {
            _personRepo = new PersonRepositoryADO();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class with a specified data repository.
        /// </summary>
        /// <param name="personRepo">The repository instance used for data access operations.</param>
        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Asynchronously retrieves all person records from the data store.
        /// </summary>
        /// <returns>
        /// An <see cref="OperationResults{PersonReadDTO}"/> containing the list of retrieved persons on success, 
        /// or error details if no data is found.
        /// </returns>
        public async Task<OperationResults<PersonReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _personRepo.GetAllAsync());
        }

        /// <summary>
        /// Asynchronously determines whether a person exists with the specified person ID.
        /// </summary>
        /// <param name="id">The unique identifier of the person to check.</param>
        /// <returns>
        /// <see langword="true"/> if the person exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _personRepo.ExistsAsync(id);
        }

        /// <summary>
        /// Asynchronously adds a new person record after validating that the national number is unique.
        /// </summary>
        /// <param name="dto">The data transfer object containing the new person's details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Int32}"/> containing the generated Person ID upon success, 
        /// or a failure result if a conflict occurs or insertion fails.
        /// </returns>
        public async Task<OperationResult<int>> AddAsync(PersonAddDTO dto)
        {
            if (await _personRepo.ExistsByNationalNoAsync(dto.NationalNo))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "Person with the same National Number already exists.");
            }

            int addResult = await _personRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Person added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add person.");
        }

        /// <summary>
        /// Asynchronously retrieves the total count of person records in the data store.
        /// </summary>
        /// <returns>The total number of registered persons.</returns>
        public async Task<int> GetCountAsync()
        {
            return await _personRepo.CountAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a person record by their unique ID.
        /// </summary>
        /// <param name="personId">The unique identifier of the person.</param>
        /// <returns>
        /// An <see cref="OperationResult{PersonReadDTO}"/> containing the person data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<PersonReadDTO>> GetByIdAsync(int personId)
        {
            var data = await _personRepo.FindAsync(personId);
            if (data == null || data.PersonID <= 0)
            {
                return OperationResult<PersonReadDTO>.Failure(ErrorCode.NotFound, "No Person Data Found.");
            }

            return OperationResult<PersonReadDTO>.Success(MapToReadDTO(data), "Person Data Retrieved Successfully.");
        }
                /// <summary>
        /// Asynchronously deletes a person record by their unique ID after verifying existence and database constraints.
        /// </summary>
        /// <param name="id">The unique identifier of the person to delete.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the deletion succeeded, 
        /// or an error describing why deletion failed (e.g., entity not found or referenced in other records).
        /// </returns>
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            
            PersonDeletionResult deletionResult = await _personRepo.DeleteAsync(id);
            if (deletionResult != PersonDeletionResult.Successful)
            {
                string errorMessage = deletionResult switch
                {
                    PersonDeletionResult.NotFound => "Person not found.",
                    PersonDeletionResult.HasUser => "Cannot delete this person because they have an active user account.",
                    PersonDeletionResult.HasApplication => "Cannot delete this person because they have linked applications.",
                    PersonDeletionResult.HasDriver => "Cannot delete this person because they have a registered driver record.",
                    _ => "An unexpected error occurred while attempting to delete the person."
                };

                return OperationResult<bool>.Failure(ErrorCode.Conflict, errorMessage);
            }

            return OperationResult<bool>.Success(true, "Person deleted successfully.");
        }

        /// <summary>
        /// Asynchronously updates an existing person record after verifying existence and checking for national number uniqueness conflicts.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated person details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the update operation succeeded or failed.
        /// </returns>
        public async Task<OperationResult<bool>> UpdateAsync(PersonUpdateDTO dto)
        {
            Person? person = await _personRepo.FindAsync(dto.PersonID);
            if (person == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Person with ID {dto.PersonID} is not found.");
            }

            if (person.NationalNo != dto.NationalNo)
            {
                if (await _personRepo.ExistsByNationalNoAsync(dto.NationalNo))
                {
                    return OperationResult<bool>.Failure(ErrorCode.Conflict, "Person with exact same National Number already exists.");
                }
            }

            bool isUpdated = await _personRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update person.");
            }

            return OperationResult<bool>.Success(true, "Person updated successfully.");
        }

        /// <summary>
        /// Asynchronously retrieves a person record by their national identification number.
        /// </summary>
        /// <param name="nationalNo">The national number of the person to search for.</param>
        /// <returns>
        /// An <see cref="OperationResult{PersonReadDTO}"/> containing the person data if found; 
        /// otherwise, a failure result indicating the record was not found.
        /// </returns>
        public async Task<OperationResult<PersonReadDTO>> GetByNationalNoAsync(string nationalNo)
        {
            var data = await _personRepo.FindByNationalNoAsync(nationalNo);
            if (data == null)
            {
                return OperationResult<PersonReadDTO>.Failure(ErrorCode.NotFound, "No Person Data Found.");
            }

            return OperationResult<PersonReadDTO>.Success(MapToReadDTO(data), "Person Data Retrieved Successfully.");
        }

        /// <summary>
        /// Asynchronously determines whether a person exists with the specified national identification number.
        /// </summary>
        /// <param name="nationalNo">The national number to check for existence.</param>
        /// <returns>
        /// <see langword="true"/> if a person with the given national number exists; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> ExistsByNationalNoAsync(string nationalNo)
        {
            return await _personRepo.ExistsByNationalNoAsync(nationalNo);
        }

        /// <summary>
        /// Asynchronously deletes a person record by their national identification number.
        /// </summary>
        /// <param name="nationalNo">The national number of the person to delete.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the deletion succeeded, 
        /// or an error describing why deletion failed.
        /// </returns>
        public async Task<OperationResult<bool>> DeleteByNationalNoAsync(string nationalNo)
        {
            PersonDeletionResult deletionResult = await _personRepo.DeleteByNationalNoAsync(nationalNo);
            if (deletionResult != PersonDeletionResult.Successful)
            {
                string errorMessage = deletionResult switch
                {
                    PersonDeletionResult.NotFound => "Person not found.",
                    PersonDeletionResult.HasUser => "Cannot delete this person because they have an active user account.",
                    PersonDeletionResult.HasApplication => "Cannot delete this person because they have linked applications.",
                    PersonDeletionResult.HasDriver => "Cannot delete this person because they have a registered driver record.",
                    _ => "An unexpected error occurred while attempting to delete the person."
                };

                return OperationResult<bool>.Failure(ErrorCode.Conflict, errorMessage);
            }

            return OperationResult<bool>.Success(true, "Person deleted successfully.");
        }

        /// <summary>
        /// Asynchronously updates a person record identified by their national number.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated person details.</param>
        /// <returns>
        /// An <see cref="OperationResult{Boolean}"/> indicating whether the update operation succeeded or failed.
        /// </returns>
        public async Task<OperationResult<bool>> UpdateByNationalNoAsync(PersonUpdateDTO dto)
        {
            if (!await _personRepo.ExistsByNationalNoAsync(dto.NationalNo))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Person with national ID {dto.NationalNo} is not found.");
            }

            bool isUpdated = await _personRepo.UpdateByNationalNoAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update person.");
            }

            return OperationResult<bool>.Success(true, "Person updated successfully.");
        }

        #endregion
    }
}