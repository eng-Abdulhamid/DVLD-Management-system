using DVLD.DAL.Entities;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
using DVLD.DAL.Interfaces.IRepositories;
namespace DVLD.DAL.Repo.ADONet
{
    public class ApplicationRepositoryADO : IApplicationRepository
    {
        public async Task<int> AddAsync(Application ApplicationDetails)
        {
            string Query = @"INSERT INTO Applications 
                (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                VALUES 
                (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationDetails.ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDetails.ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationDetails.ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationDetails.ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", ApplicationDetails.LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", ApplicationDetails.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", ApplicationDetails.CreatedByUserID);

            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public async Task<bool> UpdateStatusAsync(int applicationID, byte newStatus)
        {
            string query = @"UPDATE Applications 
                     SET ApplicationStatus = @ApplicationStatus, 
                         LastStatusDate = @LastStatusDate 
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", newStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }
        public async Task<Application?> FindAsync(int ApplicationID)
        {
            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            return await DbExecutor.ExecuteReaderSingleAsync<Application, ApplicationColumnIndices>(Command, ApplicationMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int ApplicationID)
        {
            string Query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }

        public async Task<bool> UpdateAsync(Application UpdatedApplication)
        {
            string Query = @"UPDATE Applications SET 
                ApplicantPersonID = @ApplicantPersonID,
                ApplicationDate = @ApplicationDate,
                ApplicationTypeID = @ApplicationTypeID,
                ApplicationStatus = @ApplicationStatus,
                LastStatusDate = @LastStatusDate,
                PaidFees = @PaidFees
                WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query);

            Command.Parameters.AddWithValue("@ApplicationID", UpdatedApplication.ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", UpdatedApplication.ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", UpdatedApplication.ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", UpdatedApplication.ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", UpdatedApplication.ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", UpdatedApplication.LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", UpdatedApplication.PaidFees);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }

        public async Task<bool> ExistsAsync(int ApplicationID)
        {
            string Query = "SELECT 1 FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "SELECT COUNT(*) AS ApplicationCount FROM Applications";

            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }

        public async Task<List<Application>> GetAllAsync()
        {
            string Query = "SELECT * FROM Applications";
            SqlCommand Command = new SqlCommand(Query);

            return await DbExecutor.ExecuteReaderListAsync<Application, ApplicationColumnIndices>(Command, ApplicationMapper.FromReader);
        }
    }
}