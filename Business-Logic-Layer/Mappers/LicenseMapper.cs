using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using Entities;

namespace DVLD.BLL.Mappers
{
    internal static class LicenseMapper
    {
        public static OperationResults<LicenseReadDTO> MapToOperationResult(List<License> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<LicenseReadDTO>.Failure(ErrorCode.NotFound, "There is no license data found.");
            }

            return OperationResults<LicenseReadDTO>.Success(MapToReadDTOs(data), "Licenses retrieved successfully.");
        }

        public static LicenseReadDTO MapToReadDTO(License entity)
        {
            if (entity == null) return null!;

            return new LicenseReadDTO
            {
                LicenseID = entity.LicenseID,
                ApplicationID = entity.ApplicationID,
                DriverID = entity.DriverID,
                LicenseClass = entity.LicenseClass,
                IssueDate = entity.IssueDate,
                ExpirationDate = entity.ExpirationDate,
                Notes = entity.Notes,
                PaidFees = entity.PaidFees,
                IsActive = entity.IsActive,
                IssueReason = entity.IssueReason,
                CreatedByUserID = entity.CreatedByUserID
            };
        }

        public static List<LicenseReadDTO> MapToReadDTOs(List<License> entitiesList)
        {
            var results = new List<LicenseReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static License MapToEntity(LicenseUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new License
            {
                LicenseID = dto.LicenseID,
                ApplicationID = dto.ApplicationID,
                DriverID = dto.DriverID,
                LicenseClass = dto.LicenseClass,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                Notes = dto.Notes,
                PaidFees = dto.PaidFees,
                IsActive = dto.IsActive,
                IssueReason = dto.IssueReason
            };
        }

        public static License MapToEntity(LicenseAddDTO dto)
        {
            if (dto == null) return null!;

            return new License
            {
                ApplicationID = dto.ApplicationID,
                DriverID = dto.DriverID,
                LicenseClass = dto.LicenseClass,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                Notes = dto.Notes,
                PaidFees = dto.PaidFees,
                IsActive = dto.IsActive,
                IssueReason = dto.IssueReason,
                CreatedByUserID = dto.CreatedByUserID
            };
        }
    }
}