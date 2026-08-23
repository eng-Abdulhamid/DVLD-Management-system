using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public class CountryColumnIndices : IColumnIndices<CountryColumnIndices>
    {
        public int CountryId { get; init; }
        public int CountryName { get; init; }

        public static CountryColumnIndices Create(SqlDataReader reader)
        {
            return new CountryColumnIndices
            {
                CountryId = reader.GetOrdinal("CountryID"),
                CountryName = reader.GetOrdinal("CountryName")
            };
        }
    }

    public static class CountryMapper
    {
        public static async Task<Country> FromReader(SqlDataReader reader, CountryColumnIndices indices)
        {
            return new Country
            {
                CountryID = reader.GetInt32(indices.CountryId),
                CountryName = reader.GetString(indices.CountryName)
            };
        }
    }
}