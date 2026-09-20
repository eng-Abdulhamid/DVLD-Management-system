using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DVLD.BLL.Mappers.LicenseMapper;

namespace DVLD.BLL.Services
{
    public class LicenseService
    {
        #region Constructors

        private readonly ILicenseRepository _licenseRepo;

        public LicenseService()
        {
            _licenseRepo = new LicenseRepositoryADO();
        }

        public LicenseService(ILicenseRepository licenseRepo)
        {
            _licenseRepo = licenseRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<LicenseReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _licenseRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _licenseRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(LicenseAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "License data cannot be null.");
            }

            int addResult = await _licenseRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "License issued successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to issue license.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _licenseRepo.CountAsync();
        }

        public async Task<OperationResult<LicenseReadDTO>> GetByIdAsync(int licenseId)
        {
            var data = await _licenseRepo.FindAsync(licenseId);
            if (data == null || data.LicenseID <= 0)
            {
                return OperationResult<LicenseReadDTO>.Failure(ErrorCode.NotFound, "No license data found.");
            }

            return OperationResult<LicenseReadDTO>.Success(MapToReadDTO(data), "License data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _licenseRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "License not found.");
            }

            bool isDeleted = await _licenseRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete license because it has associated records (detentions or international licenses).");
            }

            return OperationResult<bool>.Success(true, "License deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(LicenseUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "License data cannot be null.");
            }

            var existingLicense = await _licenseRepo.FindAsync(dto.LicenseID);
            if (existingLicense == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"License with ID {dto.LicenseID} is not found.");
            }

            var entity = MapToEntity(dto);
            entity.CreatedByUserID = existingLicense.CreatedByUserID;

            bool isUpdated = await _licenseRepo.UpdateAsync(entity);
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update license.");
            }

            return OperationResult<bool>.Success(true, "License updated successfully.");
        }

        #endregion

        #region Domain Specific Methods

        public async Task<OperationResults<LicenseReadDTO>> GetDriverLicensesAsync(int driverId)
        {
            var licenses = await _licenseRepo.GetDriverLicensesAsync(driverId);
            return MapToOperationResult(licenses);
        }

        public async Task<OperationResult<int?>> GetActiveLicenseIdByPersonIdAsync(int personId, int licenseClassId)
        {
            int? activeLicenseId = await _licenseRepo.GetActiveLicenseIdByPersonIdAsync(personId, licenseClassId);
            if (!activeLicenseId.HasValue)
            {
                return OperationResult<int?>.Failure(ErrorCode.NotFound, "No active license found for this person and class.");
            }

            return OperationResult<int?>.Success(activeLicenseId, "Active license retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeactivateLicenseAsync(int licenseId)
        {
            if (!await _licenseRepo.ExistsAsync(licenseId))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "License not found.");
            }

            bool result = await _licenseRepo.DeactivateLicenseAsync(licenseId);
            if (!result)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to deactivate license.");
            }

            return OperationResult<bool>.Success(true, "License deactivated successfully.");
        }

        #endregion
    }
}