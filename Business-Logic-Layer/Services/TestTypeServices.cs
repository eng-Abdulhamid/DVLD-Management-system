using System;
using System.Threading.Tasks;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.TestTypeMapper;

namespace DVLD.BLL.Services
{
    public class TestTypeService
    {
        #region Constructors

        private readonly ITestTypeRepository _testTypeRepo;

        public TestTypeService()
        {
            _testTypeRepo = new TestTypeRepositoryADO();
        }

        public TestTypeService(ITestTypeRepository testTypeRepo)
        {
            _testTypeRepo = testTypeRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<TestTypeReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _testTypeRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _testTypeRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(TestTypeAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Test type data cannot be null.");
            }

            if (await _testTypeRepo.ExistsByTitleAsync(dto.TestTypeTitle))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "Test type with the same title already exists.");
            }

            int addResult = await _testTypeRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Test type added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add test type.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _testTypeRepo.CountAsync();
        }

        public async Task<OperationResult<TestTypeReadDTO>> GetByIdAsync(int testTypeId)
        {
            var data = await _testTypeRepo.FindAsync(testTypeId);
            if (data == null || data.TestTypeID <= 0)
            {
                return OperationResult<TestTypeReadDTO>.Failure(ErrorCode.NotFound, "No test type data found.");
            }

            return OperationResult<TestTypeReadDTO>.Success(MapToReadDTO(data), "Test type data retrieved successfully.");
        }

        public async Task<OperationResult<TestTypeReadDTO>> GetByTitleAsync(string title)
        {
            var data = await _testTypeRepo.FindByTitleAsync(title);
            if (data == null)
            {
                return OperationResult<TestTypeReadDTO>.Failure(ErrorCode.NotFound, "No test type data found.");
            }

            return OperationResult<TestTypeReadDTO>.Success(MapToReadDTO(data), "Test type data retrieved successfully.");
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _testTypeRepo.ExistsByTitleAsync(title);
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _testTypeRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Test type not found.");
            }

            bool isDeleted = await _testTypeRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete test type because it is linked to test appointments.");
            }

            return OperationResult<bool>.Success(true, "Test type deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(TestTypeUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Test type data cannot be null.");
            }

            TestType? existingType = await _testTypeRepo.FindAsync(dto.TestTypeID);
            if (existingType == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Test type with ID {dto.TestTypeID} is not found.");
            }

            if (!string.Equals(existingType.TestTypeTitle, dto.TestTypeTitle, StringComparison.OrdinalIgnoreCase))
            {
                if (await _testTypeRepo.ExistsByTitleAsync(dto.TestTypeTitle))
                {
                    return OperationResult<bool>.Failure(ErrorCode.Conflict, "Test type with the same title already exists.");
                }
            }

            bool isUpdated = await _testTypeRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update test type.");
            }

            return OperationResult<bool>.Success(true, "Test type updated successfully.");
        }

        #endregion
    }
}