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
using static DVLD.BLL.Mappers.InternationalLicenseMapper;

namespace DVLD.BLL.Services
{
    public class InternationalLicenseService
    {
        #region Constructors

        private readonly IInternationalLicenseRepository _internationalLicenseRepo;

        public InternationalLicenseService()
        {
            _internationalLicenseRepo = new InternationalLicenseRepositoryADO();
        }

        public InternationalLicenseService(IInternationalLicenseRepository internationalLicenseRepo)
        {
            _internationalLicenseRepo = internationalLicenseRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<InternationalLicenseReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _internationalLicenseRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _internationalLicenseRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(InternationalLicenseAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "International license data cannot be null.");
            }

            int? activeLicenseId = await _internationalLicenseRepo.GetActiveInternationalLicenseIdByDriverIdAsync(dto.DriverID);
            if (activeLicenseId.HasValue)
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "Driver already has an active international license.");
            }

            int addResult = await _internationalLicenseRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "International license issued successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to issue international license.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _internationalLicenseRepo.CountAsync();
        }

        public async Task<OperationResult<InternationalLicenseReadDTO>> GetByIdAsync(int internationalLicenseId)
        {
            var data = await _internationalLicenseRepo.FindAsync(internationalLicenseId);
            if (data == null || data.InternationalLicenseID <= 0)
            {
                return OperationResult<InternationalLicenseReadDTO>.Failure(ErrorCode.NotFound, "No international license data found.");
            }

            return OperationResult<InternationalLicenseReadDTO>.Success(MapToReadDTO(data), "International license data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _internationalLicenseRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "International license not found.");
            }

            bool isDeleted = await _internationalLicenseRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete international license due to database constraints.");
            }

            return OperationResult<bool>.Success(true, "International license deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(InternationalLicenseUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "International license data cannot be null.");
            }

            if (!await _internationalLicenseRepo.ExistsAsync(dto.InternationalLicenseID))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"International license with ID {dto.InternationalLicenseID} is not found.");
            }

            bool isUpdated = await _internationalLicenseRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update international license.");
            }

            return OperationResult<bool>.Success(true, "International license updated successfully.");
        }

        #endregion

        #region Domain Specific Methods

        public async Task<OperationResults<InternationalLicenseReadDTO>> GetDriverInternationalLicensesAsync(int driverId)
        {
            var licenses = await _internationalLicenseRepo.GetDriverInternationalLicensesAsync(driverId);
            return MapToOperationResult(licenses);
        }

        public async Task<OperationResult<int?>> GetActiveInternationalLicenseIdByDriverIdAsync(int driverId)
        {
            int? activeLicenseId = await _internationalLicenseRepo.GetActiveInternationalLicenseIdByDriverIdAsync(driverId);
            if (!activeLicenseId.HasValue)
            {
                return OperationResult<int?>.Failure(ErrorCode.NotFound, "No active international license found for this driver.");
            }

            return OperationResult<int?>.Success(activeLicenseId, "Active international license retrieved successfully.");
        }

        #endregion
    }
}