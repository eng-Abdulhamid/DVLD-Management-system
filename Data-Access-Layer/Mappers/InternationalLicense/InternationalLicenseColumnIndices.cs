using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class InternationalLicenseColumnIndices : IColumnIndices<InternationalLicenseColumnIndices>
    {
        public int InternationalLicenseID { get; init; }
        public int ApplicationID { get; init; }
        public int DriverID { get; init; }
        public int IssuedUsingLocalLicenseID { get; init; }
        public int IssueDate { get; init; }
        public int ExpirationDate { get; init; }
        public int IsActive { get; init; }
        public int CreatedByUserID { get; init; }

        public static InternationalLicenseColumnIndices Create(SqlDataReader reader)
        {
            return new InternationalLicenseColumnIndices
            {
                InternationalLicenseID = reader.GetOrdinal("InternationalLicenseID"),
                ApplicationID = reader.GetOrdinal("ApplicationID"),
                DriverID = reader.GetOrdinal("DriverID"),
                IssuedUsingLocalLicenseID = reader.GetOrdinal("IssuedUsingLocalLicenseID"),
                IssueDate = reader.GetOrdinal("IssueDate"),
                ExpirationDate = reader.GetOrdinal("ExpirationDate"),
                IsActive = reader.GetOrdinal("IsActive"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID")
            };
        }
    }
}