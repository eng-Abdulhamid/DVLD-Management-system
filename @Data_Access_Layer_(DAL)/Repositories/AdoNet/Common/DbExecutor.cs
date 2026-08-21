using System;
using System.Data.SqlClient;
using DVLD.DAL.Common;
using DVLD.DAL.Enums;
using DVLD.DAL.SearchCriteria;

namespace DVLD.DAL.Repo.ADOnet
{
    internal static class DbExecutor
    {
        internal static int ExecuteScalarReturnInt(SqlCommand command)
        {
            int result = -1;

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                command.Connection = connection;

                try
                {
                    connection.Open();

                    object value = command.ExecuteScalar();

                    if (value != null && int.TryParse(value.ToString(), out int parsedResult))
                    {
                        result = parsedResult;
                    }
                }
                catch (Exception ex)
                {
                    result = -1;
                    Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );
                }
            }

            return result;
        }

        internal static bool ExecuteCommandReturnBoolean(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }

                    return Convert.ToInt32(result) == 1;
                }
                catch (Exception ex)
                {
                    Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );

                    return false;
                }
            }
        }

        internal static int ExecuteCommandReturnRowsAffected(SqlCommand command)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    rowsAffected = -1;

                    Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );
                }
            }

            return rowsAffected;
        }
    }
}