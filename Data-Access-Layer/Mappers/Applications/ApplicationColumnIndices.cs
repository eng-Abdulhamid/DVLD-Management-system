using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class ApplicationColumnIndices : IColumnIndices<ApplicationColumnIndices>
    {
        public int ApplicationID { get; init; }
        public int ApplicantPersonID { get; init; }
        public int ApplicationDate { get; init; }
        public int ApplicationTypeID { get; init; }
        public int ApplicationStatus { get; init; }
        public int LastStatusDate { get; init; }
        public int PaidFees { get; init; }
        public int CreatedByUserID { get; init; }

        public static ApplicationColumnIndices Create(SqlDataReader reader)
        {
            return new ApplicationColumnIndices
            {
                ApplicationID = reader.GetOrdinal("ApplicationID"),
                ApplicantPersonID = reader.GetOrdinal("ApplicantPersonID"),
                ApplicationDate = reader.GetOrdinal("ApplicationDate"),
                ApplicationTypeID = reader.GetOrdinal("ApplicationTypeID"),
                ApplicationStatus = reader.GetOrdinal("ApplicationStatus"),
                LastStatusDate = reader.GetOrdinal("LastStatusDate"),
                PaidFees = reader.GetOrdinal("PaidFees"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID")
            };
        }
    }
}