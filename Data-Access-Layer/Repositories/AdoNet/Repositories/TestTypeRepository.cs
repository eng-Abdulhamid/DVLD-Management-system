using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class TestTypeRepositoryADO : ITestTypeRepository
    {
        public async Task<int> AddAsync(TestType testType)
        {
            string query = @"INSERT INTO TestTypes 
                (TestTypeTitle, TestTypeDescription, TestTypeFees)
                VALUES 
                (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@TestTypeTitle", testType.TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", testType.TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", testType.TestTypeFees);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<TestType?> FindAsync(int testTypeID)
        {
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            return await DbExecutor.ExecuteReaderSingleAsync<TestType, TestTypeColumnIndices>(command, TestTypeMapper.FromReader);
        }

        public async Task<TestType?> FindByTitleAsync(string testTypeTitle)
        {
            string query = "SELECT TOP 1 * FROM TestTypes WHERE TestTypeTitle = @TestTypeTitle";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);

            return await DbExecutor.ExecuteReaderSingleAsync<TestType, TestTypeColumnIndices>(command, TestTypeMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int testTypeID)
        {
            string query = "DELETE FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(TestType updatedTestType)
        {
            string query = @"UPDATE TestTypes SET 
                TestTypeTitle = @TestTypeTitle,
                TestTypeDescription = @TestTypeDescription,
                TestTypeFees = @TestTypeFees
                WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@TestTypeID", updatedTestType.TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", updatedTestType.TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", updatedTestType.TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", updatedTestType.TestTypeFees);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int testTypeID)
        {
            string query = "SELECT 1 FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<bool> ExistsByTitleAsync(string testTypeTitle)
        {
            string query = "SELECT 1 FROM TestTypes WHERE TestTypeTitle = @TestTypeTitle";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS TestTypesCount FROM TestTypes");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<TestType>> GetAllAsync()
        {
            string query = "SELECT * FROM TestTypes ORDER BY TestTypeID";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<TestType, TestTypeColumnIndices>(command, TestTypeMapper.FromReader);
        }
    }
}