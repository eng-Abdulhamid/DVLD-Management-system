using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class LocalDrivingLicenseApplicationMapper
    {
        public async static Task<LocalDrivingLicenseApplication> FromReader(SqlDataReader reader, LocalDrivingLicenseApplicationColumnIndices indices)
        {
            try
            {
                return new LocalDrivingLicenseApplication
                {
                    LocalDrivingLicenseApplicationID = reader.GetInt32(indices.LocalDrivingLicenseApplicationID),
                    ApplicationID = reader.GetInt32(indices.ApplicationID),
                    LicenseClassID = reader.GetInt32(indices.LicenseClassID)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new LocalDrivingLicenseApplication();
            }
        }
    }
}