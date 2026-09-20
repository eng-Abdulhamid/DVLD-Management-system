using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class TestColumnIndices : IColumnIndices<TestColumnIndices>
    {
        public int TestID { get; init; }
        public int TestAppointmentID { get; init; }
        public int TestResult { get; init; }
        public int Notes { get; init; }
        public int CreatedByUserID { get; init; }

        public static TestColumnIndices Create(SqlDataReader reader)
        {
            return new TestColumnIndices
            {
                TestID = reader.GetOrdinal("TestID"),
                TestAppointmentID = reader.GetOrdinal("TestAppointmentID"),
                TestResult = reader.GetOrdinal("TestResult"),
                Notes = reader.GetOrdinal("Notes"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID")
            };
        }
    }
}