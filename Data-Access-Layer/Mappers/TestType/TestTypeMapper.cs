using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class TestTypeMapper
    {
        public async static Task<TestType> FromReader(SqlDataReader reader, TestTypeColumnIndices indices)
        {
            try
            {
                return new TestType
                {
                    TestTypeID = reader.GetInt32(indices.TestTypeID),
                    TestTypeTitle = reader.GetString(indices.TestTypeTitle),
                    TestTypeDescription = reader.GetString(indices.TestTypeDescription),
                    TestTypeFees = reader.GetDecimal(indices.TestTypeFees)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new TestType();
            }
        }
    }
}