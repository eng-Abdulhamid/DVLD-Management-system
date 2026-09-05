using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Repo.ADONet
{
    public class LicenseClassRepositoryADO : ILicenseClassRepository
    {
        public async Task<int> AddAsync(LicenseClass licenseClass)
        {
            string query = @"INSERT INTO LicenseClasses 
                (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                VALUES 
                (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@ClassName", licenseClass.ClassName);
            command.Parameters.AddWithValue("@ClassDescription", licenseClass.ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", licenseClass.MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", licenseClass.DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", licenseClass.ClassFees);

            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<LicenseClass?> FindAsync(int licenseClassID)
        {
            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            return await DbExecutor.ExecuteReaderSingleAsync<LicenseClass, LicenseClassColumnIndices>(command, LicenseClassMapper.FromReader);
        }

        public async Task<LicenseClass?> FindByNameAsync(string className)
        {
            string query = "SELECT TOP 1 * FROM LicenseClasses WHERE ClassName = @ClassName";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ClassName", className);

            return await DbExecutor.ExecuteReaderSingleAsync<LicenseClass, LicenseClassColumnIndices>(command, LicenseClassMapper.FromReader);
        }

        public async Task<bool> DeleteAsync(int licenseClassID)
        {
            string query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> UpdateAsync(LicenseClass updatedLicenseClass)
        {
            string query = @"UPDATE LicenseClasses SET 
                ClassName = @ClassName,
                ClassDescription = @ClassDescription,
                MinimumAllowedAge = @MinimumAllowedAge,
                DefaultValidityLength = @DefaultValidityLength,
                ClassFees = @ClassFees
                WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new(query);

            command.Parameters.AddWithValue("@LicenseClassID", updatedLicenseClass.LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", updatedLicenseClass.ClassName);
            command.Parameters.AddWithValue("@ClassDescription", updatedLicenseClass.ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", updatedLicenseClass.MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", updatedLicenseClass.DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", updatedLicenseClass.ClassFees);

            return await DbExecutor.ExecuteCommandReturnRowsAffected(command) > 0;
        }

        public async Task<bool> ExistsAsync(int licenseClassID)
        {
            string query = "SELECT 1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<bool> ExistsByNameAsync(string className)
        {
            string query = "SELECT 1 FROM LicenseClasses WHERE ClassName = @ClassName";
            SqlCommand command = new(query);
            command.Parameters.AddWithValue("@ClassName", className);

            return await DbExecutor.ExecuteCommandReturnBoolean(command);
        }

        public async Task<int> CountAsync()
        {
            SqlCommand command = new("SELECT COUNT(*) AS LicenseClassesCount FROM LicenseClasses");
            return await DbExecutor.ExecuteScalarReturnInt(command);
        }

        public async Task<List<LicenseClass>> GetAllAsync()
        {
            string query = "SELECT * FROM LicenseClasses ORDER BY LicenseClassID";
            SqlCommand command = new(query);

            return await DbExecutor.ExecuteReaderListAsync<LicenseClass, LicenseClassColumnIndices>(command, LicenseClassMapper.FromReader);
        }
    }
}