using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class LocalDrivingLicenseApplicationRepositoryADO : ILocalDrivingLicenseApplicationRepository
    {
        public async Task<int> AddAsync(LocalDrivingLicenseApplication application)
        {
            string query = @"INSERT INTO LocalDrivingLicenseApplications 
                (ApplicationID, LicenseClassID)
                VALUES 
                (@ApplicationID, @LicenseClassID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", application.LicenseClassID);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<LocalDrivingLicenseApplication?> FindAsync(int localDrivingLicenseApplicationID)
        {
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            return await DbExecutor.ExecuteReaderSingleAsync<LocalDrivingLicenseApplication, LocalDrivingLicenseApplicationColumnIndices>(command, LocalDrivingLicenseApplicationMapper.FromReader);
        }

        public async Task<LocalDrivingLicenseApplication?> FindByApplicationIdAsync(int applicationID)
        {
            string query = "SELECT TOP 1 * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            return await DbExecutor.ExecuteReaderSingleAsync<LocalDrivingLicenseApplication, LocalDrivingLicenseApplicationColumnIndices>(command, LocalDrivingLicenseApplicationMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int localDrivingLicenseApplicationID)
        {
            string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(LocalDrivingLicenseApplication updatedApplication)
        {
            string query = @"UPDATE LocalDrivingLicenseApplications SET 
                ApplicationID = @ApplicationID,
                LicenseClassID = @LicenseClassID
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", updatedApplication.LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", updatedApplication.ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", updatedApplication.LicenseClassID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int localDrivingLicenseApplicationID)
        {
            string query = "SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS LocalDrivingLicenseApplicationsCount FROM LocalDrivingLicenseApplications");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<LocalDrivingLicenseApplication>> GetAllAsync()
        {
            string query = "SELECT * FROM LocalDrivingLicenseApplications ORDER BY LocalDrivingLicenseApplicationID DESC";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<LocalDrivingLicenseApplication, LocalDrivingLicenseApplicationColumnIndices>(command, LocalDrivingLicenseApplicationMapper.FromReader);
        }
    }
}