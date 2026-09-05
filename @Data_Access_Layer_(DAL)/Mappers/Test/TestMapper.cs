using System;
using System.Threading.Tasks;
using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class TestMapper
    {
        public async static Task<Test> FromReader(SqlDataReader reader, TestColumnIndices indices)
        {
            try
            {
                return new Test
                {
                    TestID = reader.GetInt32(indices.TestID),
                    TestAppointmentID = reader.GetInt32(indices.TestAppointmentID),
                    TestResult = reader.GetBoolean(indices.TestResult),
                    Notes = reader.IsDBNull(indices.Notes) ? string.Empty : reader.GetString(indices.Notes),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new Test();
            }
        }
    }
}