using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class InternationalLicenseMapper
    {
        public async static Task<InternationalLicense> FromReader(SqlDataReader reader, InternationalLicenseColumnIndices indices)
        {
            try
            {
                return new InternationalLicense
                {
                    InternationalLicenseID = reader.GetInt32(indices.InternationalLicenseID),
                    ApplicationID = reader.GetInt32(indices.ApplicationID),
                    DriverID = reader.GetInt32(indices.DriverID),
                    IssuedUsingLocalLicenseID = reader.GetInt32(indices.IssuedUsingLocalLicenseID),
                    IssueDate = reader.GetDateTime(indices.IssueDate),
                    ExpirationDate = reader.GetDateTime(indices.ExpirationDate),
                    IsActive = reader.GetBoolean(indices.IsActive),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new InternationalLicense();
            }
        }
    }
}