using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class ApplicationMapper
    {
        public async static Task<Application> FromReader(SqlDataReader reader, ApplicationColumnIndices indices)
        {
            try
            {
                return new Application
                {
                    ApplicationID = reader.GetInt32(indices.ApplicationID),
                    ApplicantPersonID = reader.GetInt32(indices.ApplicantPersonID),
                    ApplicationDate = reader.GetDateTime(indices.ApplicationDate),
                    ApplicationTypeID = reader.GetInt32(indices.ApplicationTypeID),
                    ApplicationStatus = reader.GetByte(indices.ApplicationStatus),
                    LastStatusDate = reader.GetDateTime(indices.LastStatusDate),
                    PaidFees = reader.GetDecimal(indices.PaidFees),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new Application();
            }
        }
    }
}