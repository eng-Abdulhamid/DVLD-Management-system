using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class ApplicationTypeRepositoryADO : IApplicationTypeRepository
    {
        public async Task<int> AddAsync(ApplicationType applicationType)
        {
            string query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees)
                             VALUES (@ApplicationTypeTitle, @ApplicationFees);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationType.ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", applicationType.ApplicationFees);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<ApplicationType?> FindAsync(int applicationTypeID)
        {
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

            return await DbExecutor.ExecuteReaderSingleAsync<ApplicationType, ApplicationTypeColumnIndices>(command, ApplicationTypeMapper.FromReader);
        }

        public async Task<ApplicationType?> FindByTitleAsync(string title)
        {
            string query = "SELECT TOP 1 * FROM ApplicationTypes WHERE ApplicationTypeTitle = @ApplicationTypeTitle";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", title);

            return await DbExecutor.ExecuteReaderSingleAsync<ApplicationType, ApplicationTypeColumnIndices>(command, ApplicationTypeMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int applicationTypeID)
        {
            string query = "DELETE FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(ApplicationType updatedApplicationType)
        {
            string query = @"UPDATE ApplicationTypes 
                             SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                 ApplicationFees = @ApplicationFees
                             WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeID", updatedApplicationType.ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", updatedApplicationType.ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", updatedApplicationType.ApplicationFees);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int applicationTypeID)
        {
            string query = "SELECT 1 FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            string query = "SELECT 1 FROM ApplicationTypes WHERE ApplicationTypeTitle = @ApplicationTypeTitle";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", title);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS ApplicationTypesCount FROM ApplicationTypes");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<ApplicationType>> GetAllAsync()
        {
            string query = "SELECT * FROM ApplicationTypes ORDER BY ApplicationTypeID";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<ApplicationType, ApplicationTypeColumnIndices>(command, ApplicationTypeMapper.FromReader);
        }
    }
}