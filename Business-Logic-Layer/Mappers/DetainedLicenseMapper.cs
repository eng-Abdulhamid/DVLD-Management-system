using System.Collections.Generic;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    internal static class DetainedLicenseMapper
    {
        public static OperationResults<DetainedLicenseReadDTO> MapToOperationResult(List<DetainedLicense> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<DetainedLicenseReadDTO>.Failure(ErrorCode.NotFound, "There is no detained license data found.");
            }

            return OperationResults<DetainedLicenseReadDTO>.Success(MapToReadDTOs(data), "Detained licenses retrieved successfully.");
        }

        public static DetainedLicenseReadDTO MapToReadDTO(DetainedLicense entity)
        {
            if (entity == null) return null!;

            return new DetainedLicenseReadDTO
            {
                DetainID = entity.DetainID,
                LicenseID = entity.LicenseID,
                DetainDate = entity.DetainDate,
                FineFees = entity.FineFees,
                CreatedByUserID = entity.CreatedByUserID,
                IsReleased = entity.IsReleased,
                ReleaseDate = entity.ReleaseDate,
                ReleasedByUserID = entity.ReleasedByUserID,
                ReleaseApplicationID = entity.ReleaseApplicationID
            };
        }

        public static List<DetainedLicenseReadDTO> MapToReadDTOs(List<DetainedLicense> entitiesList)
        {
            var results = new List<DetainedLicenseReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static DetainedLicense MapToEntity(DetainedLicenseUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new DetainedLicense
            {
                DetainID = dto.DetainID,
                LicenseID = dto.LicenseID,
                DetainDate = dto.DetainDate,
                FineFees = dto.FineFees,
                IsReleased = dto.IsReleased,
                ReleaseDate = dto.ReleaseDate,
                ReleasedByUserID = dto.ReleasedByUserID,
                ReleaseApplicationID = dto.ReleaseApplicationID
            };
        }

        public static DetainedLicense MapToEntity(DetainedLicenseAddDTO dto)
        {
            if (dto == null) return null!;

            return new DetainedLicense
            {
                LicenseID = dto.LicenseID,
                DetainDate = dto.DetainDate,
                FineFees = dto.FineFees,
                CreatedByUserID = dto.CreatedByUserID,
                IsReleased = false,
                ReleaseDate = null,
                ReleasedByUserID = null,
                ReleaseApplicationID = null
            };
        }
    }
}   