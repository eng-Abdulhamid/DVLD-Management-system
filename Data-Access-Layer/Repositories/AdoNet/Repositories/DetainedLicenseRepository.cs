using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class DetainedLicenseRepositoryADO : IDetainedLicenseRepository
    {
        public async Task<int> AddAsync(DetainedLicense detainedLicense)
        {
            string query = @"INSERT INTO DetainedLicenses 
                (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                VALUES 
                (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@LicenseID", detainedLicense.LicenseID);
            command.Parameters.AddWithValue("@DetainDate", detainedLicense.DetainDate);
            command.Parameters.AddWithValue("@FineFees", detainedLicense.FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", detainedLicense.CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", detainedLicense.IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", detainedLicense.ReleaseDate.HasValue ? (object)detainedLicense.ReleaseDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", detainedLicense.ReleasedByUserID.HasValue ? (object)detainedLicense.ReleasedByUserID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", detainedLicense.ReleaseApplicationID.HasValue ? (object)detainedLicense.ReleaseApplicationID.Value : DBNull.Value);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<DetainedLicense?> FindAsync(int detainID)
        {
            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@DetainID", detainID);

            return await DbExecutor.ExecuteReaderSingleAsync<DetainedLicense, DetainedLicenseColumnIndices>(command, DetainedLicenseMapper.FromReader);
        }

        public async Task<DetainedLicense?> FindByLicenseIdAsync(int licenseID)
        {
            string query = "SELECT TOP 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID ORDER BY DetainID DESC";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            return await DbExecutor.ExecuteReaderSingleAsync<DetainedLicense, DetainedLicenseColumnIndices>(command, DetainedLicenseMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int detainID)
        {
            string query = "DELETE FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@DetainID", detainID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(DetainedLicense updatedDetainedLicense)
        {
            string query = @"UPDATE DetainedLicenses SET 
                LicenseID = @LicenseID,
                DetainDate = @DetainDate,
                FineFees = @FineFees,
                IsReleased = @IsReleased,
                ReleaseDate = @ReleaseDate,
                ReleasedByUserID = @ReleasedByUserID,
                ReleaseApplicationID = @ReleaseApplicationID
                WHERE DetainID = @DetainID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@DetainID", updatedDetainedLicense.DetainID);
            command.Parameters.AddWithValue("@LicenseID", updatedDetainedLicense.LicenseID);
            command.Parameters.AddWithValue("@DetainDate", updatedDetainedLicense.DetainDate);
            command.Parameters.AddWithValue("@FineFees", updatedDetainedLicense.FineFees);
            command.Parameters.AddWithValue("@IsReleased", updatedDetainedLicense.IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", updatedDetainedLicense.ReleaseDate.HasValue ? (object)updatedDetainedLicense.ReleaseDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", updatedDetainedLicense.ReleasedByUserID.HasValue ? (object)updatedDetainedLicense.ReleasedByUserID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", updatedDetainedLicense.ReleaseApplicationID.HasValue ? (object)updatedDetainedLicense.ReleaseApplicationID.Value : DBNull.Value);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ReleaseDetainedLicenseAsync(int detainID, int releasedByUserID, int releaseApplicationID)
        {
            string query = @"UPDATE DetainedLicenses SET 
                IsReleased = 1,
                ReleaseDate = @ReleaseDate,
                ReleasedByUserID = @ReleasedByUserID,
                ReleaseApplicationID = @ReleaseApplicationID
                WHERE DetainID = @DetainID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@DetainID", detainID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int detainID)
        {
            string query = "SELECT 1 FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@DetainID", detainID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<bool> IsLicenseDetainedAsync(int licenseID)
        {
            string query = "SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS DetainedLicensesCount FROM DetainedLicenses");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<DetainedLicense>> GetAllAsync()
        {
            string query = "SELECT * FROM DetainedLicenses ORDER BY DetainID DESC";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<DetainedLicense, DetainedLicenseColumnIndices>(command, DetainedLicenseMapper.FromReader);
        }
    }
}