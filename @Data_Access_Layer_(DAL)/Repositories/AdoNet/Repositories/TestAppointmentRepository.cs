using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class TestAppointmentRepositoryADO : ITestAppointmentRepository
    {
        public async Task<int> AddAsync(TestAppointment testAppointment)
        {
            string query = @"INSERT INTO TestAppointments 
                (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                VALUES 
                (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@TestTypeID", testAppointment.TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", testAppointment.LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", testAppointment.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", testAppointment.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", testAppointment.CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", testAppointment.IsLocked);
            command.Parameters.AddWithValue("@RetakeTestApplicationID", testAppointment.RetakeTestApplicationID.HasValue ? (object)testAppointment.RetakeTestApplicationID.Value : DBNull.Value);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<TestAppointment?> FindAsync(int testAppointmentID)
        {
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            return await DbExecutor.ExecuteReaderSingleAsync<TestAppointment, TestAppointmentColumnIndices>(command, TestAppointmentMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int testAppointmentID)
        {
            string query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(TestAppointment updatedTestAppointment)
        {
            string query = @"UPDATE TestAppointments SET 
                TestTypeID = @TestTypeID,
                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                AppointmentDate = @AppointmentDate,
                PaidFees = @PaidFees,
                IsLocked = @IsLocked,
                RetakeTestApplicationID = @RetakeTestApplicationID
                WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@TestAppointmentID", updatedTestAppointment.TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", updatedTestAppointment.TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", updatedTestAppointment.LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", updatedTestAppointment.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", updatedTestAppointment.PaidFees);
            command.Parameters.AddWithValue("@IsLocked", updatedTestAppointment.IsLocked);
            command.Parameters.AddWithValue("@RetakeTestApplicationID", updatedTestAppointment.RetakeTestApplicationID.HasValue ? (object)updatedTestAppointment.RetakeTestApplicationID.Value : DBNull.Value);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int testAppointmentID)
        {
            string query = "SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS TestAppointmentsCount FROM TestAppointments");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<TestAppointment>> GetAllAsync()
        {
            string query = "SELECT * FROM TestAppointments ORDER BY TestAppointmentID DESC";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<TestAppointment, TestAppointmentColumnIndices>(command, TestAppointmentMapper.FromReader);
        }

        public async Task<List<TestAppointment>> GetApplicationTestAppointmentsPerTestTypeAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            string query = @"SELECT * FROM TestAppointments 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                               AND TestTypeID = @TestTypeID 
                             ORDER BY TestAppointmentID DESC";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            return await DbExecutor.ExecuteReaderListAsync<TestAppointment, TestAppointmentColumnIndices>(command, TestAppointmentMapper.FromReader);
        }

        public async Task<TestAppointment?> GetLastTestAppointmentAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            string query = @"SELECT TOP 1 * FROM TestAppointments 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                               AND TestTypeID = @TestTypeID 
                             ORDER BY TestAppointmentID DESC";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            return await DbExecutor.ExecuteReaderSingleAsync<TestAppointment, TestAppointmentColumnIndices>(command, TestAppointmentMapper.FromReader);
        }

        public async Task<bool> LockAsync(int testAppointmentID)
        {
            string query = "UPDATE TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }
    }
}