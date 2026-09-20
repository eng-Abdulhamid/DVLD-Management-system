using System.Collections.Generic;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    internal static class LocalDrivingLicenseApplicationMapper
    {
        public static OperationResults<LocalDrivingLicenseApplicationReadDTO> MapToOperationResult(List<LocalDrivingLicenseApplication> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<LocalDrivingLicenseApplicationReadDTO>.Failure(ErrorCode.NotFound, "There is no local driving license application data found.");
            }

            return OperationResults<LocalDrivingLicenseApplicationReadDTO>.Success(MapToReadDTOs(data), "Local driving license applications retrieved successfully.");
        }

        public static LocalDrivingLicenseApplicationReadDTO MapToReadDTO(LocalDrivingLicenseApplication entity)
        {
            if (entity == null) return null!;

            return new LocalDrivingLicenseApplicationReadDTO
            {
                LocalDrivingLicenseApplicationID = entity.LocalDrivingLicenseApplicationID,
                ApplicationID = entity.ApplicationID,
                LicenseClassID = entity.LicenseClassID
            };
        }

        public static List<LocalDrivingLicenseApplicationReadDTO> MapToReadDTOs(List<LocalDrivingLicenseApplication> entitiesList)
        {
            var results = new List<LocalDrivingLicenseApplicationReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static LocalDrivingLicenseApplication MapToEntity(LocalDrivingLicenseApplicationUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new LocalDrivingLicenseApplication
            {
                LocalDrivingLicenseApplicationID = dto.LocalDrivingLicenseApplicationID,
                ApplicationID = dto.ApplicationID,
                LicenseClassID = dto.LicenseClassID
            };
        }

        public static LocalDrivingLicenseApplication MapToEntity(LocalDrivingLicenseApplicationAddDTO dto)
        {
            if (dto == null) return null!;

            return new LocalDrivingLicenseApplication
            {
                ApplicationID = dto.ApplicationID,
                LicenseClassID = dto.LicenseClassID
            };
        }
    }
}