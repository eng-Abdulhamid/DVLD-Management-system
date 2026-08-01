using DataAccessLayer;
using System;
using System.Data.SqlClient;

namespace Repositories
{

    internal static class DAMethods
    {
        internal static string _GetSortingString(enSorting Sorting)
        {
            string strSorting = "asc";
            switch (Sorting)
            {
                case enSorting.Ascending:
                    strSorting = "asc";
                    break;
                case enSorting.Descending:
                    strSorting = "desc";
                    break;
            }
            return strSorting;
        }
        internal static string _GetPatternSearchString(enSearchType SearchType, string SearchText)
        {
            if (string.IsNullOrEmpty(SearchText)) return "%";
            string LikePattern = SearchText;
            switch (SearchType)
            {
                case enSearchType.Contain:
                    LikePattern = "%" + (string.IsNullOrEmpty(SearchText) ? "" : SearchText) + "%";
                    break;
                case enSearchType.StartWith:
                    LikePattern = (string.IsNullOrEmpty(SearchText) ? "" : SearchText) + "%";
                    break;
                case enSearchType.EndWith:
                    LikePattern = "%" + (string.IsNullOrEmpty(SearchText) ? "" : SearchText);
                    break;
                case enSearchType.None:
                default:
                    LikePattern = SearchText;
                    break;
            }
            return LikePattern;
        }
        internal static int _ExecuteScalarReturnInt(SqlCommand Command)
        {
            int Result = -1;
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                Command.Connection = conn;
                try
                {
                    conn.Open();
                    object reader = Command.ExecuteScalar();
                    if (reader != null && int.TryParse(reader.ToString(), out int res))
                    {
                        Result = res;
                    }
                }
                catch (Exception ex)
                {
                    Result = -1;
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return Result;
        }
        internal static bool _ExecuteCommandReturnBoolean(SqlCommand Command)
        {
            bool Result = false;
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                if (Command.Connection == null)
                {
                    Command.Connection = conn;
                }
                try
                {
                    conn.Open();
                    object result = Command.ExecuteScalar();
                    if (result == null) return false;
                    return Convert.ToInt32(result) == 1;
                }
                catch (Exception ex)
                {
                    Result = false;
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return Result;
        }
        internal static int _ExecuteCommandReturnRowAffected(SqlCommand Command)
        {
            int RowAffected = 0;
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
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
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return RowAffected;
        }
    }
}
