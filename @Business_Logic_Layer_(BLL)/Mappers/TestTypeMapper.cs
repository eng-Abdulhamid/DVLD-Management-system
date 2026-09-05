using System.Collections.Generic;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    internal static class TestTypeMapper
    {
        public static OperationResults<TestTypeReadDTO> MapToOperationResult(List<TestType> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<TestTypeReadDTO>.Failure(ErrorCode.NotFound, "There is no test type data found.");
            }

            return OperationResults<TestTypeReadDTO>.Success(MapToReadDTOs(data), "Test types retrieved successfully.");
        }

        public static TestTypeReadDTO MapToReadDTO(TestType entity)
        {
            if (entity == null) return null!;

            return new TestTypeReadDTO
            {
                TestTypeID = entity.TestTypeID,
                TestTypeTitle = entity.TestTypeTitle,
                TestTypeDescription = entity.TestTypeDescription,
                TestTypeFees = entity.TestTypeFees
            };
        }

        public static List<TestTypeReadDTO> MapToReadDTOs(List<TestType> entitiesList)
        {
            var results = new List<TestTypeReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static TestType MapToEntity(TestTypeUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new TestType
            {
                TestTypeID = dto.TestTypeID,
                TestTypeTitle = dto.TestTypeTitle,
                TestTypeDescription = dto.TestTypeDescription,
                TestTypeFees = dto.TestTypeFees
            };
        }

        public static TestType MapToEntity(TestTypeAddDTO dto)
        {
            if (dto == null) return null!;

            return new TestType
            {
                TestTypeTitle = dto.TestTypeTitle,
                TestTypeDescription = dto.TestTypeDescription,
                TestTypeFees = dto.TestTypeFees
            };
        }
    }
}