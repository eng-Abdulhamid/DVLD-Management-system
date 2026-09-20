using System;
using System.Threading.Tasks;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.DetainedLicenseMapper;

namespace DVLD.BLL.Services
{
    public class DetainedLicenseService
    {
        #region Constructors

        private readonly IDetainedLicenseRepository _detainedLicenseRepo;

        public DetainedLicenseService()
        {
            _detainedLicenseRepo = new DetainedLicenseRepositoryADO();
        }

        public DetainedLicenseService(IDetainedLicenseRepository detainedLicenseRepo)
        {
            _detainedLicenseRepo = detainedLicenseRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<DetainedLicenseReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _detainedLicenseRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _detainedLicenseRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(DetainedLicenseAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "Detained license data cannot be null.");
            }

            if (await _detainedLicenseRepo.IsLicenseDetainedAsync(dto.LicenseID))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "This license is already detained.");
            }

            int addResult = await _detainedLicenseRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "License detained successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to detain license.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _detainedLicenseRepo.CountAsync();
        }

        public async Task<OperationResult<DetainedLicenseReadDTO>> GetByIdAsync(int detainId)
        {
            var data = await _detainedLicenseRepo.FindAsync(detainId);
            if (data == null || data.DetainID <= 0)
            {
                return OperationResult<DetainedLicenseReadDTO>.Failure(ErrorCode.NotFound, "No detained license record found.");
            }

            return OperationResult<DetainedLicenseReadDTO>.Success(MapToReadDTO(data), "Detained license data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _detainedLicenseRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Detained record not found.");
            }

            bool isDeleted = await _detainedLicenseRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to delete detained license record.");
            }

            return OperationResult<bool>.Success(true, "Detained record deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(DetainedLicenseUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Detained license data cannot be null.");
            }

            if (!await _detainedLicenseRepo.ExistsAsync(dto.DetainID))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"Detained record with ID {dto.DetainID} is not found.");
            }

            bool isUpdated = await _detainedLicenseRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update detained license record.");
            }

            return OperationResult<bool>.Success(true, "Detained record updated successfully.");
        }

        #endregion

        #region Domain Specific Methods

        public async Task<OperationResult<DetainedLicenseReadDTO>> GetByLicenseIdAsync(int licenseId)
        {
            var data = await _detainedLicenseRepo.FindByLicenseIdAsync(licenseId);
            if (data == null || data.DetainID <= 0)
            {
                return OperationResult<DetainedLicenseReadDTO>.Failure(ErrorCode.NotFound, "No detain record found for this license.");
            }

            return OperationResult<DetainedLicenseReadDTO>.Success(MapToReadDTO(data), "Detained license data retrieved successfully.");
        }

        public async Task<bool> IsLicenseDetainedAsync(int licenseId)
        {
            return await _detainedLicenseRepo.IsLicenseDetainedAsync(licenseId);
        }

        public async Task<OperationResult<bool>> ReleaseDetainedLicenseAsync(int detainId, int releasedByUserId, int releaseApplicationId)
        {
            var record = await _detainedLicenseRepo.FindAsync(detainId);
            if (record == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "Detained record not found.");
            }

            if (record.IsReleased)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "This license is already released.");
            }

            bool isReleased = await _detainedLicenseRepo.ReleaseDetainedLicenseAsync(detainId, releasedByUserId, releaseApplicationId);
            if (!isReleased)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to release detained license.");
            }

            return OperationResult<bool>.Success(true, "Detained license released successfully.");
        }

        #endregion
    }
}