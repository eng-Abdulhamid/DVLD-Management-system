using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class CountryRepositoryADO : ICountryRepository
    {
        public async Task<int> AddAsync(Country countryDetails)
        {
            string query = @"INSERT INTO Countries (CountryName)
                             VALUES (@CountryName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryName", countryDetails.CountryName);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<Country?> FindAsync(int countryID)
        {
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryID", countryID);

            return await DbExecutor.ExecuteReaderSingleAsync<Country, CountryColumnIndices>(command, CountryMapper.FromReader);
        }

        public async Task<Country?> FindByNameAsync(string countryName)
        {
            string query = "SELECT TOP 1 * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryName", countryName);

            return await DbExecutor.ExecuteReaderSingleAsync<Country, CountryColumnIndices>(command, CountryMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int countryID)
        {
            string query = "DELETE FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryID", countryID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(Country updatedCountry)
        {
            string query = @"UPDATE Countries 
                             SET CountryName = @CountryName 
                             WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryID", updatedCountry.CountryID);
            command.Parameters.AddWithValue("@CountryName", updatedCountry.CountryName);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int countryID)
        {
            string query = "SELECT 1 FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryID", countryID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<bool> ExistsByNameAsync(string countryName)
        {
            string query = "SELECT 1 FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CountryName", countryName);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) AS CountriesCount FROM Countries");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<Country>> GetAllAsync()
        {
            string query = "SELECT * FROM Countries ORDER BY CountryName";
            SqlCommand command = new SqlCommand(query);

            return await DbExecutor.ExecuteReaderListAsync<Country, CountryColumnIndices>(command, CountryMapper.FromReader);
        }
    }
}