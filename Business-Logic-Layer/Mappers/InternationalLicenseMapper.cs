using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using Entities;

namespace DVLD.BLL.Mappers
{
    internal static class InternationalLicenseMapper
    {
        public static OperationResults<InternationalLicenseReadDTO> MapToOperationResult(List<InternationalLicense> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<InternationalLicenseReadDTO>.Failure(ErrorCode.NotFound, "There is no international license data found.");
            }

            return OperationResults<InternationalLicenseReadDTO>.Success(MapToReadDTOs(data), "International licenses retrieved successfully.");
        }

        public static InternationalLicenseReadDTO MapToReadDTO(InternationalLicense entity)
        {
            if (entity == null) return null!;

            return new InternationalLicenseReadDTO
            {
                InternationalLicenseID = entity.InternationalLicenseID,
                ApplicationID = entity.ApplicationID,
                DriverID = entity.DriverID,
                IssuedUsingLocalLicenseID = entity.IssuedUsingLocalLicenseID,
                IssueDate = entity.IssueDate,
                ExpirationDate = entity.ExpirationDate,
                IsActive = entity.IsActive,
                CreatedByUserID = entity.CreatedByUserID
            };
        }

        public static List<InternationalLicenseReadDTO> MapToReadDTOs(List<InternationalLicense> entitiesList)
        {
            var results = new List<InternationalLicenseReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static InternationalLicense MapToEntity(InternationalLicenseUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new InternationalLicense
            {
                InternationalLicenseID = dto.InternationalLicenseID,
                ApplicationID = dto.ApplicationID,
                DriverID = dto.DriverID,
                IssuedUsingLocalLicenseID = dto.IssuedUsingLocalLicenseID,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                IsActive = dto.IsActive
            };
        }

        public static InternationalLicense MapToEntity(InternationalLicenseAddDTO dto)
        {
            if (dto == null) return null!;

            return new InternationalLicense
            {
                ApplicationID = dto.ApplicationID,
                DriverID = dto.DriverID,
                IssuedUsingLocalLicenseID = dto.IssuedUsingLocalLicenseID,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                IsActive = dto.IsActive,
                CreatedByUserID = dto.CreatedByUserID
            };
        }
    }
}