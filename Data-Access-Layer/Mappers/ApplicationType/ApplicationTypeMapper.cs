using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class ApplicationTypeMapper
    {
        public async static Task<ApplicationType> FromReader(SqlDataReader reader, ApplicationTypeColumnIndices indices)
        {
            try
            {
                return new ApplicationType
                {
                    ApplicationTypeID = reader.GetInt32(indices.ApplicationTypeID),
                    ApplicationTypeTitle = reader.GetString(indices.ApplicationTypeTitle),
                    ApplicationFees = reader.GetDecimal(indices.ApplicationFees)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new ApplicationType();
            }
        }
    }
}