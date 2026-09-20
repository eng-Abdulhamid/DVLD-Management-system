using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using Entities;
using System.Collections.Generic;

namespace DVLD.BLL.Mappers
{
    internal static class LicenseClassMapper
    {
        public static OperationResults<LicenseClassReadDTO> MapToOperationResult(List<LicenseClass> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<LicenseClassReadDTO>.Failure(ErrorCode.NotFound, "There is no license class data found.");
            }

            return OperationResults<LicenseClassReadDTO>.Success(MapToReadDTOs(data), "License classes retrieved successfully.");
        }

        public static LicenseClassReadDTO MapToReadDTO(LicenseClass entity)
        {
            if (entity == null) return null!;

            return new LicenseClassReadDTO
            {
                LicenseClassID = entity.LicenseClassID,
                ClassName = entity.ClassName,
                ClassDescription = entity.ClassDescription,
                MinimumAllowedAge = entity.MinimumAllowedAge,
                DefaultValidityLength = entity.DefaultValidityLength,
                ClassFees = entity.ClassFees
            };
        }

        public static List<LicenseClassReadDTO> MapToReadDTOs(List<LicenseClass> entitiesList)
        {
            var results = new List<LicenseClassReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static LicenseClass MapToEntity(LicenseClassUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new LicenseClass
            {
                LicenseClassID = dto.LicenseClassID,
                ClassName = dto.ClassName,
                ClassDescription = dto.ClassDescription,
                MinimumAllowedAge = dto.MinimumAllowedAge,
                DefaultValidityLength = dto.DefaultValidityLength,
                ClassFees = dto.ClassFees
            };
        }

        public static LicenseClass MapToEntity(LicenseClassAddDTO dto)
        {
            if (dto == null) return null!;

            return new LicenseClass
            {
                ClassName = dto.ClassName,
                ClassDescription = dto.ClassDescription,
                MinimumAllowedAge = dto.MinimumAllowedAge,
                DefaultValidityLength = dto.DefaultValidityLength,
                ClassFees = dto.ClassFees
            };
        }
    }
}