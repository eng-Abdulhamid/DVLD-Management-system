using System;
using System.Threading.Tasks;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.TestMapper;

namespace DVLD.BLL.Services
{
    public class TestService
    {
        #region Constructors

        private readonly ITestRepository _testRepo;

        public TestService()
        {
            _testRepo = new TestRepositoryADO();
        }

        public TestService(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<TestReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _testRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _testRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(TestAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Test data cannot be null.");
            }

            int addResult = await _testRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Test record submitted successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to submit test record.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _testRepo.CountAsync();
        }

        public async Task<OperationResult<TestReadDTO>> GetByIdAsync(int testId)
        {
            var data = await _testRepo.FindAsync(testId);
            if (data == null || data.TestID <= 0)
            {
                return OperationResult<TestReadDTO>.Failure(ErrorCode.NotFound, "No test data found.");
            }

            return OperationResult<TestReadDTO>.Success(MapToReadDTO(data), "Test data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _testRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Test record not found.");
            }

            bool isDeleted = await _testRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to delete test record.");
            }

            return OperationResult<bool>.Success(true, "Test record deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(TestUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Test data cannot be null.");
            }

            if (!await _testRepo.ExistsAsync(dto.TestID))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Test with ID {dto.TestID} is not found.");
            }

            bool isUpdated = await _testRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update test record.");
            }

            return OperationResult<bool>.Success(true, "Test record updated successfully.");
        }

        #endregion

        #region Domain Specific Methods

        public async Task<OperationResult<TestReadDTO>> GetByTestAppointmentIdAsync(int testAppointmentId)
        {
            var data = await _testRepo.FindByTestAppointmentIdAsync(testAppointmentId);
            if (data == null || data.TestID <= 0)
            {
                return OperationResult<TestReadDTO>.Failure(ErrorCode.NotFound, "No test trial found for this appointment.");
            }

            return OperationResult<TestReadDTO>.Success(MapToReadDTO(data), "Test record retrieved successfully.");
        }

        public async Task<byte> GetPassedTestCountAsync(int localDrivingLicenseApplicationId)
        {
            return await _testRepo.GetPassedTestCountAsync(localDrivingLicenseApplicationId);
        }

        public async Task<bool> PassedAllTestsAsync(int localDrivingLicenseApplicationId)
        {
            return await _testRepo.PassedAllTestsAsync(localDrivingLicenseApplicationId);
        }

        #endregion
    }
}