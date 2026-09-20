using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class LicenseColumnIndices : IColumnIndices<LicenseColumnIndices>
    {
        public int LicenseID { get; init; }
        public int ApplicationID { get; init; }
        public int DriverID { get; init; }
        public int LicenseClass { get; init; }
        public int IssueDate { get; init; }
        public int ExpirationDate { get; init; }
        public int Notes { get; init; }
        public int PaidFees { get; init; }
        public int IsActive { get; init; }
        public int IssueReason { get; init; }
        public int CreatedByUserID { get; init; }

        public static LicenseColumnIndices Create(SqlDataReader reader)
        {
            return new LicenseColumnIndices
            {
                LicenseID = reader.GetOrdinal("LicenseID"),
                ApplicationID = reader.GetOrdinal("ApplicationID"),
                DriverID = reader.GetOrdinal("DriverID"),
                LicenseClass = reader.GetOrdinal("LicenseClass"),
                IssueDate = reader.GetOrdinal("IssueDate"),
                ExpirationDate = reader.GetOrdinal("ExpirationDate"),
                Notes = reader.GetOrdinal("Notes"),
                PaidFees = reader.GetOrdinal("PaidFees"),
                IsActive = reader.GetOrdinal("IsActive"),
                IssueReason = reader.GetOrdinal("IssueReason"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID")
            };
        }
    }
}