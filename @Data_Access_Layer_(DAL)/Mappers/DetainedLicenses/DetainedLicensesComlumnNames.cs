using System;
using System.Threading.Tasks;
using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class DetainedLicenseMapper
    {
        public async static Task<DetainedLicense> FromReader(SqlDataReader reader, DetainedLicenseColumnIndices indices)
        {
            try
            {
                return new DetainedLicense
                {
                    DetainID = reader.GetInt32(indices.DetainID),
                    LicenseID = reader.GetInt32(indices.LicenseID),
                    DetainDate = reader.GetDateTime(indices.DetainDate),
                    FineFees = reader.GetDecimal(indices.FineFees),
                    CreatedByUserID = reader.GetInt32(indices.CreatedByUserID),
                    IsReleased = reader.GetBoolean(indices.IsReleased),
                    ReleaseDate = reader.IsDBNull(indices.ReleaseDate) ? null : reader.GetDateTime(indices.ReleaseDate),
                    ReleasedByUserID = reader.IsDBNull(indices.ReleasedByUserID) ? null : reader.GetInt32(indices.ReleasedByUserID),
                    ReleaseApplicationID = reader.IsDBNull(indices.ReleaseApplicationID) ? null : reader.GetInt32(indices.ReleaseApplicationID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new DetainedLicense();
            }
        }
    }
}