using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    internal static class TestMapper
    {
        public static OperationResults<TestReadDTO> MapToOperationResult(List<Test> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<TestReadDTO>.Failure(ErrorCode.NotFound, "There is no test data found.");
            }

            return OperationResults<TestReadDTO>.Success(MapToReadDTOs(data), "Tests retrieved successfully.");
        }

        public static TestReadDTO MapToReadDTO(Test entity)
        {
            if (entity == null) return null!;

            return new TestReadDTO
            {
                TestID = entity.TestID,
                TestAppointmentID = entity.TestAppointmentID,
                TestResult = entity.TestResult,
                Notes = entity.Notes,
                CreatedByUserID = entity.CreatedByUserID
            };
        }

        public static List<TestReadDTO> MapToReadDTOs(List<Test> entitiesList)
        {
            var results = new List<TestReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static Test MapToEntity(TestUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new Test
            {
                TestID = dto.TestID,
                TestAppointmentID = dto.TestAppointmentID,
                TestResult = dto.TestResult,
                Notes = dto.Notes
            };
        }

        public static Test MapToEntity(TestAddDTO dto)
        {
            if (dto == null) return null!;

            return new Test
            {
                TestAppointmentID = dto.TestAppointmentID,
                TestResult = dto.TestResult,
                Notes = dto.Notes,
                CreatedByUserID = dto.CreatedByUserID
            };
        }
    }
}