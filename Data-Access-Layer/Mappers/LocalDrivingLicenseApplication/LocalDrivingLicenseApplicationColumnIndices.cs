using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class LocalDrivingLicenseApplicationColumnIndices : IColumnIndices<LocalDrivingLicenseApplicationColumnIndices>
    {
        public int LocalDrivingLicenseApplicationID { get; init; }
        public int ApplicationID { get; init; }
        public int LicenseClassID { get; init; }

        public static LocalDrivingLicenseApplicationColumnIndices Create(SqlDataReader reader)
        {
            return new LocalDrivingLicenseApplicationColumnIndices
            {
                LocalDrivingLicenseApplicationID = reader.GetOrdinal("LocalDrivingLicenseApplicationID"),
                ApplicationID = reader.GetOrdinal("ApplicationID"),
                LicenseClassID = reader.GetOrdinal("LicenseClassID")
            };
        }
    }
}