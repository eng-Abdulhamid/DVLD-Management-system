using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{

    public static class DriverMapper
    {
        public async static Task<Driver> FromReader(SqlDataReader reader, DriverColumnIndices indices)
        {
            try
            {
                return new Driver
                {
                    DriverID = reader.GetInt32(indices.DriverID),
                    PersonID = reader.GetInt32(indices.PersonID),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID),
                    CreatedDate = reader.GetDateTime(indices.CreatedDate),
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new();
            }
        }
    }
}