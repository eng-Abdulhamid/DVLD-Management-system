using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class TestTypeColumnIndices : IColumnIndices<TestTypeColumnIndices>
    {
        public int TestTypeID { get; init; }
        public int TestTypeTitle { get; init; }
        public int TestTypeDescription { get; init; }
        public int TestTypeFees { get; init; }

        public static TestTypeColumnIndices Create(SqlDataReader reader)
        {
            return new TestTypeColumnIndices
            {
                TestTypeID = reader.GetOrdinal("TestTypeID"),
                TestTypeTitle = reader.GetOrdinal("TestTypeTitle"),
                TestTypeDescription = reader.GetOrdinal("TestTypeDescription"),
                TestTypeFees = reader.GetOrdinal("TestTypeFees")
            };
        }
    }
}