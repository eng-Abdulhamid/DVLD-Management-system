using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class DriverColumnIndices : IColumnIndices<DriverColumnIndices>
    {
        public int DriverID { get; init; }
        public int PersonID { get; init; }
        public int CreatedByUserID { get; init; }
        public int CreatedDate { get; init; }

        public static DriverColumnIndices Create(SqlDataReader reader)
        {
            return new DriverColumnIndices
            {
                DriverID = reader.GetOrdinal("DriverID"),
                PersonID = reader.GetOrdinal("PersonID"),
                CreatedByUserID = reader.GetOrdinal("CreatedByUserID"),
                CreatedDate = reader.GetOrdinal("CreatedDate")
            };
        }
    }
}