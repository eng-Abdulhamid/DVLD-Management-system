using System;
using System.Threading.Tasks;
using DVLD.DAL.Settings;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class LicenseClassMapper
    {
        public async static Task<LicenseClass> FromReader(SqlDataReader reader, LicenseClassColumnIndices indices)
        {
            try
            {
                return new LicenseClass
                {
                    LicenseClassID = reader.GetInt32(indices.LicenseClassID),
                    ClassName = reader.GetString(indices.ClassName),
                    ClassDescription = reader.GetString(indices.ClassDescription),
                    MinimumAllowedAge = reader.GetByte(indices.MinimumAllowedAge),
                    DefaultValidityLength = reader.GetByte(indices.DefaultValidityLength),
                    ClassFees = reader.GetDecimal(indices.ClassFees)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new LicenseClass();
            }
        }
    }
}