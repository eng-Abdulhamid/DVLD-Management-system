using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class TestRepositoryADO : ITestRepository
    {
        public async Task<int> AddAsync(Test test)
        {
            string query = @"INSERT INTO Tests 
                (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                VALUES 
                (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@TestAppointmentID", test.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", test.TestResult);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(test.Notes) ? (object)DBNull.Value : test.Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", test.CreatedByUserID);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<Test?> FindAsync(int testID)
        {
            string query = "SELECT * FROM Tests WHERE TestID = @TestID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestID", testID);

            return await DbExecutor.ExecuteReaderSingleAsync<Test, TestColumnIndices>(command, TestMapper.FromReader);
        }

        public async Task<Test?> FindByTestAppointmentIdAsync(int testAppointmentID)
        {
            string query = "SELECT TOP 1 * FROM Tests WHERE TestAppointmentID = @TestAppointmentID ORDER BY TestID DESC";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            return await DbExecutor.ExecuteReaderSingleAsync<Test, TestColumnIndices>(command, TestMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int testID)
        {
            string query = "DELETE FROM Tests WHERE TestID = @TestID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestID", testID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(Test updatedTest)
        {
            string query = @"UPDATE Tests SET 
                TestAppointmentID = @TestAppointmentID,
                TestResult = @TestResult,
                Notes = @Notes
                WHERE TestID = @TestID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@TestID", updatedTest.TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", updatedTest.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", updatedTest.TestResult);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(updatedTest.Notes) ? (object)DBNull.Value : updatedTest.Notes);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int testID)
        {
            string query = "SELECT 1 FROM Tests WHERE TestID = @TestID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestID", testID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS TestsCount FROM Tests");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<Test>> GetAllAsync()
        {
            string query = "SELECT * FROM Tests ORDER BY TestID DESC";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<Test, TestColumnIndices>(command, TestMapper.FromReader);
        }

        public async Task<byte> GetPassedTestCountAsync(int localDrivingLicenseApplicationID)
        {
            string query = @"SELECT COUNT(Tests.TestID) 
                             FROM Tests 
                             INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                             WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                               AND Tests.TestResult = 1";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            return (byte)await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<bool> PassedAllTestsAsync(int localDrivingLicenseApplicationID)
        {
            return await GetPassedTestCountAsync(localDrivingLicenseApplicationID) == 3;
        }
    }
}