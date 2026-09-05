using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class InternationalLicenseRepositoryADO : IInternationalLicenseRepository
    {
        public async Task<int> AddAsync(InternationalLicense license)
        {
            string query = @"INSERT INTO InternationalLicenses 
                (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                VALUES 
                (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", license.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", license.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<InternationalLicense?> FindAsync(int internationalLicenseID)
        {
            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

            return await DbExecutor.ExecuteReaderSingleAsync<InternationalLicense, InternationalLicenseColumnIndices>(command, InternationalLicenseMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int internationalLicenseID)
        {
            string query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(InternationalLicense updatedLicense)
        {
            string query = @"UPDATE InternationalLicenses SET 
                ApplicationID = @ApplicationID,
                DriverID = @DriverID,
                IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                ExpirationDate = @ExpirationDate,
                IsActive = @IsActive
                WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@InternationalLicenseID", updatedLicense.InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", updatedLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", updatedLicense.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", updatedLicense.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@ExpirationDate", updatedLicense.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", updatedLicense.IsActive);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int internationalLicenseID)
        {
            string query = "SELECT 1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS InternationalLicensesCount FROM InternationalLicenses");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<InternationalLicense>> GetAllAsync()
        {
            string query = "SELECT * FROM InternationalLicenses ORDER BY InternationalLicenseID DESC";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<InternationalLicense, InternationalLicenseColumnIndices>(command, InternationalLicenseMapper.FromReader);
        }

        public async Task<List<InternationalLicense>> GetDriverInternationalLicensesAsync(int driverID)
        {
            string query = "SELECT * FROM InternationalLicenses WHERE DriverID = @DriverID ORDER BY InternationalLicenseID DESC";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@DriverID", driverID);

            return await DbExecutor.ExecuteReaderListAsync<InternationalLicense, InternationalLicenseColumnIndices>(command, InternationalLicenseMapper.FromReader);
        }

        public async Task<int?> GetActiveInternationalLicenseIdByDriverIdAsync(int driverID)
        {
            string query = @"SELECT TOP 1 InternationalLicenseID 
                             FROM InternationalLicenses 
                             WHERE DriverID = @DriverID AND IsActive = 1 AND ExpirationDate > GETDATE()";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@DriverID", driverID);

            int result = await DbExecutor.ExecuteScalarReturnInt(command);
            return result > 0 ? result : null;
        }
    }
}