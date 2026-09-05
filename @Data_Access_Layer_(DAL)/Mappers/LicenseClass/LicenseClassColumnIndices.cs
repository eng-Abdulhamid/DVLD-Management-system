using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class LicenseClassColumnIndices : IColumnIndices<LicenseClassColumnIndices>
    {
        public int LicenseClassID { get; init; }
        public int ClassName { get; init; }
        public int ClassDescription { get; init; }
        public int MinimumAllowedAge { get; init; }
        public int DefaultValidityLength { get; init; }
        public int ClassFees { get; init; }

        public static LicenseClassColumnIndices Create(SqlDataReader reader)
        {
            return new LicenseClassColumnIndices
            {
                LicenseClassID = reader.GetOrdinal("LicenseClassID"),
                ClassName = reader.GetOrdinal("ClassName"),
                ClassDescription = reader.GetOrdinal("ClassDescription"),
                MinimumAllowedAge = reader.GetOrdinal("MinimumAllowedAge"),
                DefaultValidityLength = reader.GetOrdinal("DefaultValidityLength"),
                ClassFees = reader.GetOrdinal("ClassFees")
            };
        }
    }
}