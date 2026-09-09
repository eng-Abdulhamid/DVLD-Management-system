using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using DVLD.DAL.Mappers;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
namespace DVLD.DAL.Repo.ADONet
{
    public class UserRepositoryADO : IUserRepository
    {
       
        public async Task<int> AddAsync(User UserDetails)
        {
            string Query = @"INSERT INTO Users 
        (PersonID, UserName, Password, IsActive)
        VALUES 
        (@PersonID, @UserName, @Password, @IsActive);
        SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new(Query);

            Command.Parameters.AddWithValue("@PersonID", (int)UserDetails.PersonID);
            Command.Parameters.AddWithValue("@UserName", (string)UserDetails.UserName);
            Command.Parameters.AddWithValue("@Password", (string)UserDetails.Password);
            Command.Parameters.AddWithValue("@IsActive", (bool)UserDetails.IsActive);

            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public async Task<User?> FindAsync(int UserID)
        {
            string Query = "SELECT * From Users where UserID = @UserID";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@UserID", (object)UserID);
            User User = new();

            return await DbExecutor.ExecuteReaderSingleAsync<User, UsersColumnIndices>(Command, UserMapper.FromReader);
        }
        public async Task<UserDeletionResult> DeleteAsync(int userID)
        {
            string query = @"
        IF NOT EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID)
        BEGIN
            SELECT 0;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM Applications WHERE CreatedByUserID = @UserID)
        BEGIN
            SELECT -1;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM TestAppointments WHERE CreatedByUserID = @UserID)
        BEGIN
            SELECT -2;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM Tests WHERE CreatedByUserID = @UserID)
        BEGIN
            SELECT -3;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM Licenses WHERE CreatedByUserID = @UserID)
        BEGIN
            SELECT -4;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM Drivers WHERE CreatedByUserID = @UserID)
        BEGIN
            SELECT -5;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM DetainedLicenses WHERE CreatedByUserID = @UserID OR ReleasedByUserID = @UserID)
        BEGIN
            SELECT -6;
            RETURN;
        END

        DELETE FROM Users WHERE UserID = @UserID;
        SELECT 1;";

            using SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@UserID", userID);

            int result = await DbExecutor.ExecuteScalarReturnInt(command);
            return (UserDeletionResult)result;
        }
        public async Task<bool> UpdateAsync(User UpdatedUser)
        {
            SqlCommand Command = new()
            {
                CommandText = $@"UPDATE Users SET 
                PersonID=@PersonID,
                UserName=@UserName,
                Password=@Password,
                IsActive=@IsActive
                WHERE UserID=@UserID"
            };
            Command.Parameters.AddWithValue("@UserID", UpdatedUser.UserID);
            Command.Parameters.AddWithValue("@PersonID", (int)UpdatedUser.PersonID);
            Command.Parameters.AddWithValue("@UserName", (string)UpdatedUser.UserName);
            Command.Parameters.AddWithValue("@Password", (string)UpdatedUser.Password);
            Command.Parameters.AddWithValue("@IsActive", (bool)UpdatedUser.IsActive);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> ExistsAsync(int UserID)
        {
            string Query = $"SELECT 1 FROM Users WHERE UserID = @UserID";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue($"@UserID", UserID);
            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public async Task<int> CountAsync()
        {
            SqlCommand Command = new() {
                CommandText = $@"SELECT COUNT(*) AS UsersCount FROM Users"
            };
            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public async Task<List<User>> GetAllAsync()
        { 
            string Query = "SELECT * FROM Users";
            SqlCommand Command = new(Query);
            return await DbExecutor.ExecuteReaderListAsync<User, UsersColumnIndices>(Command, UserMapper.FromReader);
        }
        public async Task<User?> FindByUsernameAsync(string username)
        {
            string Query = "SELECT * FROM Users WHERE UserName = @UserName";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@UserName", username);
            return await DbExecutor.ExecuteReaderSingleAsync<User, UsersColumnIndices>(Command, UserMapper.FromReader);
        }
        public async Task<bool> ChangePasswordAsync(string UserName, string newPassword)
        {
            string Query = "UPDATE Users SET Password = @Password WHERE UserName = @UserName";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", newPassword);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> ChangePasswordAsync(int UserID, string newPassword)
        {
            string Query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@Password", newPassword);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
    }
}
