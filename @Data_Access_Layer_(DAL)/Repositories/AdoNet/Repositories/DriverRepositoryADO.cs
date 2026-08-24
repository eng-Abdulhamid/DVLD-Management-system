using DVLD.DAL.Entities;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
using DVLD.DAL.Interfaces.IRepositories;
namespace DVLD.DAL.Repo.ADONet
{

    public class DriverRepositoryADO : IDriverRepository
    {
        public async Task<int> AddAsync(Driver DriverDetails)
        {
            string Query = @"INSERT INTO Drivers 
                (PersonID, CreatedByUserID, CreatedDate)
                VALUES 
                (@PersonID, @CreatedByUserID, @CreatedDate);
                SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);

            Command.Parameters.AddWithValue("@PersonID", DriverDetails.PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", DriverDetails.CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", DriverDetails.CreatedDate);

            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }

        public async Task<Driver?> FindAsync(int DriverID)
        {
            string Query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            return await DbExecutor.ExecuteReaderSingleAsync<Driver, DriverColumnIndices>(Command, DriverMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int DriverID)
        {
            string Query = "DELETE FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }

        public async Task<bool> UpdateAsync(Driver UpdatedDriver)
        {
            string Query = @"UPDATE Drivers SET 
                PersonID = @PersonID, 
                CreatedByUserID = @CreatedByUserID, 
                CreatedDate = @CreatedDate
                WHERE DriverID = @DriverID";

            SqlCommand Command = new SqlCommand(Query);

            Command.Parameters.AddWithValue("@PersonID", UpdatedDriver.PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", UpdatedDriver.CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", UpdatedDriver.CreatedDate);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }

        public async Task<bool> ExistsAsync(int DriverID)
        {
            string Query = "SELECT 1 FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "SELECT COUNT(*) AS DriverCount FROM Drivers";

            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }

        public async Task<List<Driver>> GetAllAsync()
        {
            string Query = "SELECT * FROM Drivers";
            SqlCommand Command = new SqlCommand(Query);

            return await DbExecutor.ExecuteReaderListAsync<Driver, DriverColumnIndices>(Command, DriverMapper.FromReader);
        }
    }
}