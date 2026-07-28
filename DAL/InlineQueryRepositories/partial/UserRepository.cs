using DataAccessLayer;
using Entities;
using System;
using System.Data.SqlClient;
namespace Repositories
{
    public partial class UserRepository : IUserRepository
    {
        public User FindUserByUsername(string Username)
        {
            string Query = $"SELECT TOP 1 * FROM Users WHERE Username = @Username";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@Username", Username);
            User user = new User();

            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                Command.Connection = conn;
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ordUserID = reader.GetOrdinal("UserID");
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordUserName = reader.GetOrdinal("UserName");
                            int ordPassword = reader.GetOrdinal("Password");
                            int ordIsActive = reader.GetOrdinal("IsActive");
                            if (reader.Read())
                            {
                                user = _MapDataReaderToUser(reader, ordUserID, ordPersonID, ordUserName, ordPassword, ordIsActive);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    user = new User();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return user;
        }
        public User FindUserByUsernameAndPassword(string Username, string Password)
        {
            string Query = $"SELECT TOP 1 * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            User user = new User();
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                Command.Connection = conn;
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ordUserID = reader.GetOrdinal("UserID");
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordUserName = reader.GetOrdinal("UserName");
                            int ordPassword = reader.GetOrdinal("Password");
                            int ordIsActive = reader.GetOrdinal("IsActive");
                            if (reader.Read())
                            {
                                user = _MapDataReaderToUser(reader, ordUserID, ordPersonID, ordUserName, ordPassword, ordIsActive);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    user = new User();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return user;
        }
    }
}
