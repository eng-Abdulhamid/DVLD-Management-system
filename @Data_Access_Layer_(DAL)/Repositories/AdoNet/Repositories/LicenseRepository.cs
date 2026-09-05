using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class LicenseRepositoryADO : ILicenseRepository
    {
        public async Task<int> AddAsync(License license)
        {
            string query = @"INSERT INTO Licenses 
                (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                VALUES 
                (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", license.DriverID);
            command.Parameters.AddWithValue("@LicenseClass", license.LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(license.Notes) ? (object)DBNull.Value : license.Notes);
            command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
            command.Parameters.AddWithValue("@IsActive", license.IsActive);
            command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<License?> FindAsync(int licenseID)
        {
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            return await DbExecutor.ExecuteReaderSingleAsync<License, LicenseColumnIndices>(command, LicenseMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int licenseID)
        {
            string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(License updatedLicense)
        {
            string query = @"UPDATE Licenses SET 
                ApplicationID = @ApplicationID,
                DriverID = @DriverID,
                LicenseClass = @LicenseClass,
                IssueDate = @IssueDate,
                ExpirationDate = @ExpirationDate,
                Notes = @Notes,
                PaidFees = @PaidFees,
                IsActive = @IsActive,
                IssueReason = @IssueReason
                WHERE LicenseID = @LicenseID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@LicenseID", updatedLicense.LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", updatedLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", updatedLicense.DriverID);
            command.Parameters.AddWithValue("@LicenseClass", updatedLicense.LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", updatedLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", updatedLicense.ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(updatedLicense.Notes) ? (object)DBNull.Value : updatedLicense.Notes);
            command.Parameters.AddWithValue("@PaidFees", updatedLicense.PaidFees);
            command.Parameters.AddWithValue("@IsActive", updatedLicense.IsActive);
            command.Parameters.AddWithValue("@IssueReason", updatedLicense.IssueReason);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int licenseID)
        {
            string query = "SELECT 1 FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS LicensesCount FROM Licenses");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<License>> GetAllAsync()
        {
            string query = "SELECT * FROM Licenses ORDER BY LicenseID DESC";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<License, LicenseColumnIndices>(command, LicenseMapper.FromReader);
        }

        public async Task<List<License>> GetDriverLicensesAsync(int driverID)
        {
            string query = "SELECT * FROM Licenses WHERE DriverID = @DriverID ORDER BY LicenseID DESC";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@DriverID", driverID);

            return await DbExecutor.ExecuteReaderListAsync<License, LicenseColumnIndices>(command, LicenseMapper.FromReader);
        }

        public async Task<int?> GetActiveLicenseIdByPersonIdAsync(int personID, int licenseClassID)
        {
            string query = @"SELECT TOP 1 L.LicenseID 
                             FROM Licenses L
                             INNER JOIN Drivers D ON L.DriverID = D.DriverID
                             WHERE D.PersonID = @PersonID 
                               AND L.LicenseClass = @LicenseClassID 
                               AND L.IsActive = 1";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            int result = await DbExecutor.ExecuteScalarReturnInt(command);
            return result > 0 ? result : null;
        }

        public async Task<bool> DeactivateLicenseAsync(int licenseID)
        {
            string query = "UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @LicenseID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }
    }
}