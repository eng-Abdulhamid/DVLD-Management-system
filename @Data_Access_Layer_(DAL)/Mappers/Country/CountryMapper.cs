using DVLD.DAL.Entities;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
namespace DVLD.DAL.Mappers
{
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
