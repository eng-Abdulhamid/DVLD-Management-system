using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using Entities;
using System;
using System.Threading.Tasks;
using static DVLD.BLL.Mappers.LicenseClassMapper;

namespace DVLD.BLL.Services
{
    public class LicenseClassService
    {
        #region Constructors

        private readonly ILicenseClassRepository _licenseClassRepo;

        public LicenseClassService()
        {
            _licenseClassRepo = new LicenseClassRepositoryADO();
        }

        public LicenseClassService(ILicenseClassRepository licenseClassRepo)
        {
            _licenseClassRepo = licenseClassRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<LicenseClassReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _licenseClassRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _licenseClassRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(LicenseClassAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "License class data cannot be null.");
            }

            if (await _licenseClassRepo.ExistsByNameAsync(dto.ClassName))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "License class with the same name already exists.");
            }

            int addResult = await _licenseClassRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "License class added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add license class.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _licenseClassRepo.CountAsync();
        }

        public async Task<OperationResult<LicenseClassReadDTO>> GetByIdAsync(int licenseClassId)
        {
            var data = await _licenseClassRepo.FindAsync(licenseClassId);
            if (data == null || data.LicenseClassID <= 0)
            {
                return OperationResult<LicenseClassReadDTO>.Failure(ErrorCode.NotFound, "No license class data found.");
            }

            return OperationResult<LicenseClassReadDTO>.Success(MapToReadDTO(data), "License class data retrieved successfully.");
        }

        public async Task<OperationResult<LicenseClassReadDTO>> GetByNameAsync(string className)
        {
            var data = await _licenseClassRepo.FindByNameAsync(className);
            if (data == null)
            {
                return OperationResult<LicenseClassReadDTO>.Failure(ErrorCode.NotFound, "No license class data found.");
            }

            return OperationResult<LicenseClassReadDTO>.Success(MapToReadDTO(data), "License class data retrieved successfully.");
        }

        public async Task<bool> ExistsByNameAsync(string className)
        {
            return await _licenseClassRepo.ExistsByNameAsync(className);
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _licenseClassRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "License class not found.");
            }

            bool isDeleted = await _licenseClassRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete license class because it is assigned to existing licenses or applications.");
            }

            return OperationResult<bool>.Success(true, "License class deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(LicenseClassUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "License class data cannot be null.");
            }

            LicenseClass? existingClass = await _licenseClassRepo.FindAsync(dto.LicenseClassID);
            if (existingClass == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"License class with ID {dto.LicenseClassID} is not found.");
            }

            if (!string.Equals(existingClass.ClassName, dto.ClassName, StringComparison.OrdinalIgnoreCase))
            {
                if (await _licenseClassRepo.ExistsByNameAsync(dto.ClassName))
                {
                    return OperationResult<bool>.Failure(ErrorCode.Conflict, "License class with the same name already exists.");
                }
            }

            bool isUpdated = await _licenseClassRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update license class.");
            }

            return OperationResult<bool>.Success(true, "License class updated successfully.");
        }

        #endregion
    }
}