using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DVLD.BLL.Mappers.PersonMapper;

namespace DVLD.BLL.Services
{
    public class PersonService
    {
        #region Constructors

        private readonly IPersonRepository _personRepo;

        public PersonService()
        {
            _personRepo = new PersonRepositoryADO();
        }

        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<PersonReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _personRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _personRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(PersonAddDTO dto)
        {
            if (dto == null) return OperationResult<int>.Failure(ErrorCode.BadRequest);

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

        public async Task<int> GetCountAsync()
        {
            return await _personRepo.CountAsync();
        }

        public async Task<OperationResult<PersonReadDTO>> GetByIdAsync(int personId)
        {
            var data = await _personRepo.FindAsync(personId);
            if (data == null || data.PersonID <= 0)
            {
                return OperationResult<PersonReadDTO>.Failure(ErrorCode.NotFound, "No Person Data Found.");
            }

            return OperationResult<PersonReadDTO>.Success(MapToReadDTO(data), "Person Data Retrieved Successfully.");
        }

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

        public async Task<OperationResult<PersonReadDTO>> GetByNationalNoAsync(string nationalNo)
        {
            var data = await _personRepo.FindByNationalNoAsync(nationalNo);
            if (data == null)
            {
                return OperationResult<PersonReadDTO>.Failure(ErrorCode.NotFound, "No Person Data Found.");
            }

            return OperationResult<PersonReadDTO>.Success(MapToReadDTO(data), "Person Data Retrieved Successfully.");
        }

        public async Task<bool> ExistsByNationalNoAsync(string nationalNo)
        {
            return await _personRepo.ExistsByNationalNoAsync(nationalNo);
        }

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

        public async Task<bool> UpdateByNationalNoAsync(PersonUpdateDTO dto)
        {
            if (!await _personRepo.ExistsByNationalNoAsync(dto.NationalNo))
            {
                return false;
            }

            return await _personRepo.UpdateByNationalNoAsync(MapToEntity(dto));
        }

        public async Task<OperationResults<PersonReadDTO>> SearchPeoplePagedAsync(
            string filterColumn,
            string searchValue,
            string letter,
            byte? gender,
            int pageNumber,
            int pageSize)
        {
            if (string.IsNullOrWhiteSpace(filterColumn))
            {
                return OperationResults<PersonReadDTO>.Failure(ErrorCode.BadRequest, "Search column is required.");
            }

            string[] allowedColumns =
            {
                "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                "LastName", "DateOfBirth", "CountryName", "Phone", "Email"
            };

            if (!allowedColumns.Contains(filterColumn))
            {
                return OperationResults<PersonReadDTO>.Failure(ErrorCode.BadRequest, "Invalid search column.");
            }

            List<Person> data = await _personRepo.SearchPagedAsync(
                filterColumn,
                searchValue?.Trim() ?? string.Empty,
                letter?.Trim() ?? string.Empty,
                gender,
                pageNumber,
                pageSize);

            return MapToOperationResult(data);
        }

        public async Task<int> GetSearchCountAsync(
            string filterColumn,
            string searchValue,
            string letter,
            byte? gender)
        {
            if (string.IsNullOrWhiteSpace(filterColumn))
            {
                return 0;
            }

            string[] allowedColumns =
            {
                "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                "LastName", "DateOfBirth", "CountryName", "Phone", "Email"
            };

            if (!allowedColumns.Contains(filterColumn))
            {
                return 0;
            }

            return await _personRepo.GetSearchCountAsync(
                filterColumn,
                searchValue?.Trim() ?? string.Empty,
                letter?.Trim() ?? string.Empty,
                gender);
        }

        #endregion
    }
}