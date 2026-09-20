using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.TestAppointmentMapper;

namespace DVLD.BLL.Services
{
    public class TestAppointmentService
    {
        #region Constructors

        private readonly ITestAppointmentRepository _testAppointmentRepo;

        public TestAppointmentService()
        {
            _testAppointmentRepo = new TestAppointmentRepositoryADO();
        }

        public TestAppointmentService(ITestAppointmentRepository testAppointmentRepo)
        {
            _testAppointmentRepo = testAppointmentRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<TestAppointmentReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _testAppointmentRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _testAppointmentRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(TestAppointmentAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Test appointment data cannot be null.");
            }

            int addResult = await _testAppointmentRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Test appointment scheduled successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to schedule test appointment.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _testAppointmentRepo.CountAsync();
        }

        public async Task<OperationResult<TestAppointmentReadDTO>> GetByIdAsync(int testAppointmentId)
        {
            var data = await _testAppointmentRepo.FindAsync(testAppointmentId);
            if (data == null || data.TestAppointmentID <= 0)
            {
                return OperationResult<TestAppointmentReadDTO>.Failure(ErrorCode.NotFound, "No test appointment data found.");
            }

            return OperationResult<TestAppointmentReadDTO>.Success(MapToReadDTO(data), "Test appointment data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _testAppointmentRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Test appointment not found.");
            }

            bool isDeleted = await _testAppointmentRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete test appointment because it is linked to completed tests.");
            }

            return OperationResult<bool>.Success(true, "Test appointment deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(TestAppointmentUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Test appointment data cannot be null.");
            }

            var existingAppointment = await _testAppointmentRepo.FindAsync(dto.TestAppointmentID);
            if (existingAppointment == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Test appointment with ID {dto.TestAppointmentID} is not found.");
            }

            if (existingAppointment.IsLocked)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot update a locked test appointment.");
            }

            bool isUpdated = await _testAppointmentRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update test appointment.");
            }

            return OperationResult<bool>.Success(true, "Test appointment updated successfully.");
        }

        #endregion

        #region Domain Specific Methods

        public async Task<OperationResults<TestAppointmentReadDTO>> GetApplicationTestAppointmentsPerTestTypeAsync(int localDrivingLicenseApplicationId, int testTypeId)
        {
            var list = await _testAppointmentRepo.GetApplicationTestAppointmentsPerTestTypeAsync(localDrivingLicenseApplicationId, testTypeId);
            return MapToOperationResult(list);
        }

        public async Task<OperationResult<TestAppointmentReadDTO>> GetLastTestAppointmentAsync(int localDrivingLicenseApplicationId, int testTypeId)
        {
            var appointment = await _testAppointmentRepo.GetLastTestAppointmentAsync(localDrivingLicenseApplicationId, testTypeId);
            if (appointment == null)
            {
                return OperationResult<TestAppointmentReadDTO>.Failure(ErrorCode.NotFound, "No previous appointment found for this test type.");
            }

            return OperationResult<TestAppointmentReadDTO>.Success(MapToReadDTO(appointment), "Last test appointment retrieved successfully.");
        }

        public async Task<OperationResult<bool>> LockAsync(int testAppointmentId)
        {
            if (!await _testAppointmentRepo.ExistsAsync(testAppointmentId))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Test appointment not found.");
            }

            bool result = await _testAppointmentRepo.LockAsync(testAppointmentId);
            if (!result)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to lock test appointment.");
            }

            return OperationResult<bool>.Success(true, "Test appointment locked successfully.");
        }

        #endregion
    }
}