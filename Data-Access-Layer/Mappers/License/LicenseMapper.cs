using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class LicenseMapper
    {
        public async static Task<License> FromReader(SqlDataReader reader, LicenseColumnIndices indices)
        {
            try
            {
                return new License
                {
                    LicenseID = reader.GetInt32(indices.LicenseID),
                    ApplicationID = reader.GetInt32(indices.ApplicationID),
                    DriverID = reader.GetInt32(indices.DriverID),
                    LicenseClass = reader.GetInt32(indices.LicenseClass),
                    IssueDate = reader.GetDateTime(indices.IssueDate),
                    ExpirationDate = reader.GetDateTime(indices.ExpirationDate),
                    Notes = reader.IsDBNull(indices.Notes) ? string.Empty : reader.GetString(indices.Notes),
                    PaidFees = reader.GetDecimal(indices.PaidFees),
                    IsActive = reader.GetBoolean(indices.IsActive),
                    IssueReason = reader.GetByte(indices.IssueReason),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new License();
            }
        }
    }
}