using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class ApplicationColumnIndices : IColumnIndices<ApplicationColumnIndices>
    {
        public int ApplicationId { get; init; }
        public int ApplicantPersonId { get; init; }
        public int ApplicationDate { get; init; }
        public int ApplicationTypeId { get; init; }
        public int ApplicationStatus { get; init; }
        public int LastStatusDate { get; init; }
        public int PaidFees { get; init; }
        public int CreatedByUserId { get; init; }

        public static ApplicationColumnIndices Create(SqlDataReader reader)
        {
            return new ApplicationColumnIndices
            {
                ApplicationId = reader.GetOrdinal("ApplicationID"),
                ApplicantPersonId = reader.GetOrdinal("ApplicantPersonID"),
                ApplicationDate = reader.GetOrdinal("ApplicationDate"),
                ApplicationTypeId = reader.GetOrdinal("ApplicationTypeID"),
                ApplicationStatus = reader.GetOrdinal("ApplicationStatus"),
                LastStatusDate = reader.GetOrdinal("LastStatusDate"),
                PaidFees = reader.GetOrdinal("PaidFees"),
                CreatedByUserId = reader.GetOrdinal("CreatedByUserID")
            };
        }
    }
}