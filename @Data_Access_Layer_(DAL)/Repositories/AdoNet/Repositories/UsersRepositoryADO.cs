using DVLD.DAL.Entities;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
using DVLD.DAL.Interfaces.IRepositories;
using System.Data;
using DVLD.DAL.Mappers;
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
        public async Task<bool> DeleteAsync(int UserID)
        {
            string Query = $"DELETE FROM Users WHERE UserID=@UserID";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue($"@UserID", (object)UserID);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> UpdateAsync(User UpdatedUser)
        {
            SqlCommand Command = new()
            {
                CommandText = $@"UPDATE Users SET 
                PersonID=@PersonID,
                UserName=@UserName,
                Password=@Password,
                IsActive=@IsActive,
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
            string Query = "SELECT * FROM Users_View";
            SqlCommand Command = new(Query);
            return await DbExecutor.ExecuteReaderListAsync<User, UsersColumnIndices>(Command, UserMapper.FromReader);
        }
    }
}
