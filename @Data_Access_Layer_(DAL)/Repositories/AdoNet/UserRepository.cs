using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enUserField
    {
        None = 0,
        UserID,
        PersonID,
        UserName,
        Password,
        IsActive
    }
    #endregion

    public partial class UserRepository : IUserRepository
    {
        

        #region Main CRUD Operations
        public int GetCountOfAllUsers()
        {
            string Query = $"SELECT COUNT(*) AS UsersCount FROM Users";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewUser(User UserDeatils)
        {
            string Query =
                $@"INSERT INTO Users(PersonID, UserName, Password, IsActive)
                   VALUES(@PersonID, @UserName, @Password, @IsActive)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)UserDeatils.PersonID);
            Command.Parameters.AddWithValue("@UserName", (object)UserDeatils.UserName);
            Command.Parameters.AddWithValue("@Password", (object)UserDeatils.Password);
            Command.Parameters.AddWithValue("@IsActive", (object)UserDeatils.IsActive);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public User FindUserByUserID(int UserID)
        {
            string Query = $"SELECT TOP 1 * FROM Users WHERE UserID = @UserID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@UserID", (object)UserID);
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
        public bool DeleteUserByUserID(int UserID)
        {
            string Query = $"DELETE FROM Users WHERE UserID=@UserID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@UserID", (object)UserID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateUserByUserID(User UpdatedUser)
        {
            string Query = $@"UPDATE Users SET 
                PersonID=@PersonID,
                UserName=@UserName,
                Password=@Password,
                IsActive=@IsActive
                WHERE UserID=@UserID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@UserID", (object)UpdatedUser.UserID);
            Command.Parameters.AddWithValue("@PersonID", (object)UpdatedUser.PersonID);
            Command.Parameters.AddWithValue("@UserName", (object)UpdatedUser.UserName);
            Command.Parameters.AddWithValue("@Password", (object)UpdatedUser.Password);
            Command.Parameters.AddWithValue("@IsActive", (object)UpdatedUser.IsActive);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsUserExistByUserID(int UserID)
        {
            string Query = $"SELECT 1 FROM Users WHERE UserID = @UserID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@UserID", UserID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }




        public List<User> GetUsers(UsersSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllUserAtPageSearchBy' operation");
                return new List<User>();
            }

            return _ExecuteCommandReturnUsers(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<User> GetAllUsers()
        {
            string Query = "Select * from Users";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnUsers(Command);
        }
        public int GetCountOfUsersByFilter(UsersSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enUserField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetUserFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS UsersCount FROM Users
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS UsersCount FROM Users";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class UsersSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enUserField OrderBy { get; set; } = enUserField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enUserField SearchBy { get; set; } = enUserField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private User _MapDataReaderToUser(SqlDataReader reader, int ordUserID, int ordPersonID, int ordUserName, int ordPassword, int ordIsActive)
        {
            User user = new User();

            try
            {
                user.UserID =
                  (int)Convert.ChangeType(reader.GetValue(ordUserID), typeof(int));
                user.PersonID =
                  (int)Convert.ChangeType(reader.GetValue(ordPersonID), typeof(int));
                user.UserName = reader[ordUserName].ToString();
                user.Password = reader[ordPassword].ToString();
                user.IsActive =
                  (bool)Convert.ChangeType(reader.GetValue(ordIsActive), typeof(bool));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to User Entity:\n   -Error message: {ex.Message}");
                return new User(); ;
            }
            return user;
        }
        private SqlCommand _PrepareGetAllQuery(UsersSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enUserField.None && SearchCriteria.SearchBy != enUserField.None)
            {
                string strOrderBy = _GetUserFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetUserFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM Users
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enUserField.None && SearchCriteria.SearchBy != enUserField.None)
            {
                string SearchByColumnName = _GetUserFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM Users
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enUserField.None && SearchCriteria.SearchBy == enUserField.None)
            {
                string OrderByColumnName = _GetUserFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM Users
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM Users
                Order by {_GetUserFieldString(enUserField.UserID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetUserFieldString(enUserField strUserField)
        {
            string strOrderBy = "";
            switch (strUserField)
            {
                case enUserField.UserID:
                    strOrderBy = "UserID";
                    break;
                case enUserField.PersonID:
                    strOrderBy = "PersonID";
                    break;
                case enUserField.UserName:
                    strOrderBy = "UserName";
                    break;
                case enUserField.Password:
                    strOrderBy = "Password";
                    break;
                case enUserField.IsActive:
                    strOrderBy = "IsActive";
                    break;
                default:
                    strOrderBy = "UserID";
                    break;
            }
            return strOrderBy;
        }
        private List<User> _ExecuteCommandReturnUsers(SqlCommand Command)
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }
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
                            while (reader.Read())
                            {
                                users.Add(_MapDataReaderToUser(reader, ordUserID, ordPersonID, ordUserName, ordPassword, ordIsActive));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    users = new List<User>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return users;
        }
        #endregion
    }
}
