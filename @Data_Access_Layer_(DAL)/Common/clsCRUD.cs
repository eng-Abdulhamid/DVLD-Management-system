using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    
    internal class clsCRUD
    {
       
        private string _ConnectionString;
        public string ConnectionString {
            set
            {
                _ConnectionString = value;
            }
        }

        public clsCRUD(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        private T _CRUD<T>(SqlCommand Command, string strOperation, Func<T> Operation, T ErrorValue)
        {
            if (Command == null)
            {
                Logs.AppendLog(Logs.enType.Error, $"SqlCommand is null. Cannot execute {strOperation} operation.");
                return ErrorValue;
            }
            if (string.IsNullOrEmpty(Command.CommandText))
            {
                Logs.AppendLog(Logs.enType.Error, $"SqlCommand.CommandText is null or empty. Cannot execute {strOperation} operation");
                return ErrorValue;
            }
            T result = ErrorValue;
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }
                try
                {
                    conn.Open();
                    result = Operation.Invoke();
                }
                catch (Exception ex)
                {

                    Logs.AppendLog(Logs.enType.Error, ex.Message);
                }
            }
            return result;

        }

        // Return Row Affected, -1 if Error else 0 or bigger
        public int DELETE(SqlCommand Command)
        {
            if (Command == null)
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand is null. Cannot execute DELETE operation.");
                return -1;
            }
            if (string.IsNullOrEmpty(Command.CommandText))
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand.CommandText is null or empty. Cannot execute DELETE operation");
                return -1;
            }
            int RowAffected = 0;
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }
                try
                {
                    conn.Open();
                    RowAffected = Command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    RowAffected = -1;
                    Logs.AppendLog(Logs.enType.Error, ex.Message);
                }
            }
            return RowAffected;
        }
        // Return Row Affected, -1 if Error else 0 or bigger
        public int UPDATE(SqlCommand Command)
        {
            if (Command == null)
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand is null. Cannot execute UPDATE operation.");
                return -1;
            }
            if (string.IsNullOrEmpty(Command.CommandText))
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand.CommandText is null or empty. Cannot execute UPDATE operation");
                return -1;
            }

            int RowAffected = 0;
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }
                try
                {
                    conn.Open();
                    RowAffected = Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RowAffected = -1;
                    Logs.AppendLog(Logs.enType.Error, ex.Message);
                }
            }
            return RowAffected;
        }
        /* 
            Return:
                -1 if Add Success else return the ID
         */
        public int AddNewAndReturnNewID(SqlCommand Command)
        {
            if (Command == null)
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand is null. Cannot execute AddNewAndReturnNewID operation.");
                return -1;
            }
            if (string.IsNullOrEmpty(Command.CommandText))
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand.CommandText is null or empty. Cannot execute AddNewAndReturnNewID operation");
                return -1;
            }

            int ID = 0;
            if (!Command.CommandText.ToLower().Contains("scope_identity")) 
            {
                Command.CommandText += "; Select SCOPE_IDENTITY();";
            }
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }

                try
                {
                    conn.Open();
                    object result = Command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int number))
                    {
                        ID = number;
                    }
                    else
                    {
                        ID = -1;
                    }
                }
                catch (Exception ex)
                {
                    ID = -1;
                    Logs.AppendLog(Logs.enType.Error, ex.Message);
                }
            }
            return ID;
        }
        public DataTable GetDataReturnDataTable(SqlCommand Command)
        {
            if (Command == null)
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand is null. Cannot execute GetDataReturnDataTable operation.");
                return null;
            }
            if (string.IsNullOrEmpty(Command.CommandText))
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand.CommandText is null or empty. Cannot execute GetDataReturnDataTable operation");
                return null;
            }

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }
                try
                {
                    conn.Open();
                    SqlDataReader reader = Command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    dt = null;
                    Logs.AppendLog(Logs.enType.Error, ex.Message);
                }
            }
            return dt;
        }
        public bool IsExist(SqlCommand Command)
        {
            if (Command == null)
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand is null. Cannot execute IsExist operation.");
                return false;
            }
            if (string.IsNullOrEmpty(Command.CommandText))
            {
                Logs.AppendLog(Logs.enType.Error, "SqlCommand.CommandText is null or empty. Cannot execute IsExist operation");
                return false;
            }

            bool IsFound = false;
            SqlConnection conn = new SqlConnection(_ConnectionString);
            if (Command.Connection == null)
            {
                Command.Connection = conn;
            }
            try
            {
                conn.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    if (int.TryParse(result.ToString(), out int intResult))
                    {
                        IsFound = (intResult == 1);
                    }
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, ex.Message);
                IsFound = false;
            
            }
            finally
            {
                conn.Close();
            }
            return IsFound;
        }
    }
}
