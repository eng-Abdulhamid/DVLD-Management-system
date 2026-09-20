using System;
using System.Threading.Tasks;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.LocalDrivingLicenseApplicationMapper;

namespace DVLD.BLL.Services
{
    public class LocalDrivingLicenseApplicationService
    {
        #region Constructors

        private readonly ILocalDrivingLicenseApplicationRepository _ldlAppRepo;

        public LocalDrivingLicenseApplicationService()
        {
            _ldlAppRepo = new LocalDrivingLicenseApplicationRepositoryADO();
        }

        public LocalDrivingLicenseApplicationService(ILocalDrivingLicenseApplicationRepository ldlAppRepo)
        {
            _ldlAppRepo = ldlAppRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<LocalDrivingLicenseApplicationReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _ldlAppRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _ldlAppRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(LocalDrivingLicenseApplicationAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Local driving license application data cannot be null.");
            }

            int addResult = await _ldlAppRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "Local driving license application added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add local driving license application.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _ldlAppRepo.CountAsync();
        }

        public async Task<OperationResult<LocalDrivingLicenseApplicationReadDTO>> GetByIdAsync(int ldlApplicationId)
        {
            var data = await _ldlAppRepo.FindAsync(ldlApplicationId);
            if (data == null || data.LocalDrivingLicenseApplicationID <= 0)
            {
                return OperationResult<LocalDrivingLicenseApplicationReadDTO>.Failure(ErrorCode.NotFound, "No local driving license application data found.");
            }

            return OperationResult<LocalDrivingLicenseApplicationReadDTO>.Success(MapToReadDTO(data), "Local driving license application data retrieved successfully.");
        }

        public async Task<OperationResult<LocalDrivingLicenseApplicationReadDTO>> GetByApplicationIdAsync(int applicationId)
        {
            var data = await _ldlAppRepo.FindByApplicationIdAsync(applicationId);
            if (data == null || data.LocalDrivingLicenseApplicationID <= 0)
            {
                return OperationResult<LocalDrivingLicenseApplicationReadDTO>.Failure(ErrorCode.NotFound, "No local driving license application linked to this application ID.");
            }

            return OperationResult<LocalDrivingLicenseApplicationReadDTO>.Success(MapToReadDTO(data), "Local driving license application data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _ldlAppRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Local driving license application not found.");
            }

            bool isDeleted = await _ldlAppRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete local driving license application because it is linked to test appointments.");
            }

            return OperationResult<bool>.Success(true, "Local driving license application deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(LocalDrivingLicenseApplicationUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Local driving license application data cannot be null.");
            }

            if (!await _ldlAppRepo.ExistsAsync(dto.LocalDrivingLicenseApplicationID))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Local driving license application with ID {dto.LocalDrivingLicenseApplicationID} is not found.");
            }

            bool isUpdated = await _ldlAppRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update local driving license application.");
            }

            return OperationResult<bool>.Success(true, "Local driving license application updated successfully.");
        }

        #endregion
    }
}