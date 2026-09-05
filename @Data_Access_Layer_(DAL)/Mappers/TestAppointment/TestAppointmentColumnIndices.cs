using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class TestAppointmentColumnIndices : IColumnIndices<TestAppointmentColumnIndices>
    {
        public int TestAppointmentID { get; init; }
        public int TestTypeID { get; init; }
        public int LocalDrivingLicenseApplicationID { get; init; }
        public int AppointmentDate { get; init; }
        public int PaidFees { get; init; }
        public int CreatedByUserID { get; init; }
        public int IsLocked { get; init; }
        public int RetakeTestApplicationID { get; init; }

        public static TestAppointmentColumnIndices Create(SqlDataReader reader)
        {
            return new TestAppointmentColumnIndices
            {
                TestAppointmentID = reader.GetOrdinal("TestAppointmentID"),
                TestTypeID = reader.GetOrdinal("TestTypeID"),
                LocalDrivingLicenseApplicationID = reader.GetOrdinal("LocalDrivingLicenseApplicationID"),
                AppointmentDate = reader.GetOrdinal("AppointmentDate"),
                PaidFees = reader.GetOrdinal("PaidFees"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID"),
                IsLocked = reader.GetOrdinal("IsLocked"),
                RetakeTestApplicationID = reader.GetOrdinal("RetakeTestApplicationID")
            };
        }
    }
}