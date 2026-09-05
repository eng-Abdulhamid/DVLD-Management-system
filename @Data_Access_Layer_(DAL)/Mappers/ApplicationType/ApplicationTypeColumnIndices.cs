using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class ApplicationTypeColumnIndices : IColumnIndices<ApplicationTypeColumnIndices>
    {
        public int ApplicationTypeID { get; init; }
        public int ApplicationTypeTitle { get; init; }
        public int ApplicationFees { get; init; }

        public static ApplicationTypeColumnIndices Create(SqlDataReader reader)
        {
            return new ApplicationTypeColumnIndices
            {
                ApplicationTypeID = reader.GetOrdinal("ApplicationTypeID"),
                ApplicationTypeTitle = reader.GetOrdinal("ApplicationTypeTitle"),
                ApplicationFees = reader.GetOrdinal("ApplicationFees")
            };
        }
    }
}