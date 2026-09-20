using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class TestAppointmentMapper
    {
        public async static Task<TestAppointment> FromReader(SqlDataReader reader, TestAppointmentColumnIndices indices)
        {
            try
            {
                return new TestAppointment
                {
                    TestAppointmentID = reader.GetInt32(indices.TestAppointmentID),
                    TestTypeID = reader.GetInt32(indices.TestTypeID),
                    LocalDrivingLicenseApplicationID = reader.GetInt32(indices.LocalDrivingLicenseApplicationID),
                    AppointmentDate = reader.GetDateTime(indices.AppointmentDate),
                    PaidFees = reader.GetDecimal(indices.PaidFees),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID),
                    IsLocked = reader.GetBoolean(indices.IsLocked),
                    RetakeTestApplicationID = reader.IsDBNull(indices.RetakeTestApplicationID) ? null : reader.GetInt32(indices.RetakeTestApplicationID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new TestAppointment();
            }
        }
    }
}