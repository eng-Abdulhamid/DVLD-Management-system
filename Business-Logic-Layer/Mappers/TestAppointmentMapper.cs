using System.Collections.Generic;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    internal static class TestAppointmentMapper
    {
        public static OperationResults<TestAppointmentReadDTO> MapToOperationResult(List<TestAppointment> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<TestAppointmentReadDTO>.Failure(ErrorCode.NotFound, "There is no test appointment data found.");
            }

            return OperationResults<TestAppointmentReadDTO>.Success(MapToReadDTOs(data), "Test appointments retrieved successfully.");
        }

        public static TestAppointmentReadDTO MapToReadDTO(TestAppointment entity)
        {
            if (entity == null) return null!;

            return new TestAppointmentReadDTO
            {
                TestAppointmentID = entity.TestAppointmentID,
                TestTypeID = entity.TestTypeID,
                LocalDrivingLicenseApplicationID = entity.LocalDrivingLicenseApplicationID,
                AppointmentDate = entity.AppointmentDate,
                PaidFees = entity.PaidFees,
                CreatedByUserID = entity.CreatedByUserID,
                IsLocked = entity.IsLocked
            };
        }

        public static List<TestAppointmentReadDTO> MapToReadDTOs(List<TestAppointment> entitiesList)
        {
            var results = new List<TestAppointmentReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static TestAppointment MapToEntity(TestAppointmentUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new TestAppointment
            {
                TestAppointmentID = dto.TestAppointmentID,
                TestTypeID = dto.TestTypeID,
                LocalDrivingLicenseApplicationID = dto.LocalDrivingLicenseApplicationID,
                AppointmentDate = dto.AppointmentDate,
                PaidFees = dto.PaidFees,
                IsLocked = dto.IsLocked
            };
        }

        public static TestAppointment MapToEntity(TestAppointmentAddDTO dto)
        {
            if (dto == null) return null!;

            return new TestAppointment
            {
                TestTypeID = dto.TestTypeID,
                LocalDrivingLicenseApplicationID = dto.LocalDrivingLicenseApplicationID,
                AppointmentDate = dto.AppointmentDate,
                PaidFees = dto.PaidFees,
                CreatedByUserID = dto.CreatedByUserID,
                IsLocked = dto.IsLocked
            };
        }
    }
}