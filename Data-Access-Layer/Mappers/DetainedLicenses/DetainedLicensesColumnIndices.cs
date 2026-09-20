using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class DetainedLicenseColumnIndices : IColumnIndices<DetainedLicenseColumnIndices>
    {
        public int DetainID { get; init; }
        public int LicenseID { get; init; }
        public int DetainDate { get; init; }
        public int FineFees { get; init; }
        public int CreatedByUserID { get; init; }
        public int IsReleased { get; init; }
        public int ReleaseDate { get; init; }
        public int ReleasedByUserID { get; init; }
        public int ReleaseApplicationID { get; init; }

        public static DetainedLicenseColumnIndices Create(SqlDataReader reader)
        {
            return new DetainedLicenseColumnIndices
            {
                DetainID = reader.GetOrdinal("DetainID"),
                LicenseID = reader.GetOrdinal("LicenseID"),
                DetainDate = reader.GetOrdinal("DetainDate"),
                FineFees = reader.GetOrdinal("FineFees"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID"),
                IsReleased = reader.GetOrdinal("IsReleased"),
                ReleaseDate = reader.GetOrdinal("ReleaseDate"),
                ReleasedByUserID = reader.GetOrdinal("ReleasedByUserID"),
                ReleaseApplicationID = reader.GetOrdinal("ReleaseApplicationID")
            };
        }
    }
}