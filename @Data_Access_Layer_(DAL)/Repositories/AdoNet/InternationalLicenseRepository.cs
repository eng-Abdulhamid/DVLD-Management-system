using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enInternationalLicenseField
    {
        None = 0,
        InternationalLicenseID,
        ApplicationID,
        DriverID,
        IssuedUsingLocalLicenseID,
        IssueDate,
        ExpirationDate,
        IsActive,
        CreatedByUserID
    }
    #endregion

    public partial class InternationalLicenseRepository : IInternationalLicenseRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllInternationalLicenses()
        {
            string Query = $"SELECT COUNT(*) AS InternationalLicensesCount FROM InternationalLicenses";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewInternationalLicense(InternationalLicense InternationalLicenseDeatils)
        {
            string Query =
                $@"INSERT INTO InternationalLicenses(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                   VALUES(@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", (object)InternationalLicenseDeatils.ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", (object)InternationalLicenseDeatils.DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", (object)InternationalLicenseDeatils.IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", (object)InternationalLicenseDeatils.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", (object)InternationalLicenseDeatils.ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", (object)InternationalLicenseDeatils.IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)InternationalLicenseDeatils.CreatedByUserID);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public InternationalLicense FindInternationalLicenseByInternationalLicenseID(int InternationalLicenseID)
        {
            string Query = $"SELECT TOP 1 * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@InternationalLicenseID", (object)InternationalLicenseID);
            InternationalLicense internationallicense = new InternationalLicense();

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
                            int ordInternationalLicenseID = reader.GetOrdinal("InternationalLicenseID");
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordIssuedUsingLocalLicenseID = reader.GetOrdinal("IssuedUsingLocalLicenseID");
                            int ordIssueDate = reader.GetOrdinal("IssueDate");
                            int ordExpirationDate = reader.GetOrdinal("ExpirationDate");
                            int ordIsActive = reader.GetOrdinal("IsActive");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            if (reader.Read())
                            {
                                internationallicense = _MapDataReaderToInternationalLicense(reader, ordInternationalLicenseID, ordApplicationID, ordDriverID, ordIssuedUsingLocalLicenseID, ordIssueDate, ordExpirationDate, ordIsActive, ordCreatedByUserID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    internationallicense = new InternationalLicense();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return internationallicense;
        }
        public bool DeleteInternationalLicenseByInternationalLicenseID(int InternationalLicenseID)
        {
            string Query = $"DELETE FROM InternationalLicenses WHERE InternationalLicenseID=@InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@InternationalLicenseID", (object)InternationalLicenseID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateInternationalLicenseByInternationalLicenseID(InternationalLicense UpdatedInternationalLicense)
        {
            string Query = $@"UPDATE InternationalLicenses SET 
                ApplicationID=@ApplicationID,
                DriverID=@DriverID,
                IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID,
                IssueDate=@IssueDate,
                ExpirationDate=@ExpirationDate,
                IsActive=@IsActive,
                CreatedByUserID=@CreatedByUserID
                WHERE InternationalLicenseID=@InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@InternationalLicenseID", (object)UpdatedInternationalLicense.InternationalLicenseID);
            Command.Parameters.AddWithValue("@ApplicationID", (object)UpdatedInternationalLicense.ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", (object)UpdatedInternationalLicense.DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", (object)UpdatedInternationalLicense.IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", (object)UpdatedInternationalLicense.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", (object)UpdatedInternationalLicense.ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", (object)UpdatedInternationalLicense.IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedInternationalLicense.CreatedByUserID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsInternationalLicenseExistByInternationalLicenseID(int InternationalLicenseID)
        {
            string Query = $"SELECT 1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@InternationalLicenseID", InternationalLicenseID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }







        public List<InternationalLicense> GetInternationalLicenses(InternationalLicensesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllInternationalLicenseAtPageSearchBy' operation");
                return new List<InternationalLicense>();
            }

            return _ExecuteCommandReturnInternationalLicenses(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<InternationalLicense> GetAllInternationalLicenses()
        {
            string Query = "Select * from InternationalLicenses";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnInternationalLicenses(Command);
        }
        public int GetCountOfInternationalLicensesByFilter(InternationalLicensesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enInternationalLicenseField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetInternationalLicenseFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS InternationalLicensesCount FROM InternationalLicenses
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS InternationalLicensesCount FROM InternationalLicenses";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class InternationalLicensesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enInternationalLicenseField OrderBy { get; set; } = enInternationalLicenseField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enInternationalLicenseField SearchBy { get; set; } = enInternationalLicenseField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private InternationalLicense _MapDataReaderToInternationalLicense(SqlDataReader reader, int ordInternationalLicenseID, int ordApplicationID, int ordDriverID, int ordIssuedUsingLocalLicenseID, int ordIssueDate, int ordExpirationDate, int ordIsActive, int ordCreatedByUserID)
        {
            InternationalLicense internationallicense = new InternationalLicense();

            try
            {
                internationallicense.InternationalLicenseID =
                  (int)Convert.ChangeType(reader.GetValue(ordInternationalLicenseID), typeof(int));
                internationallicense.ApplicationID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicationID), typeof(int));
                internationallicense.DriverID =
                  (int)Convert.ChangeType(reader.GetValue(ordDriverID), typeof(int));
                internationallicense.IssuedUsingLocalLicenseID =
                  (int)Convert.ChangeType(reader.GetValue(ordIssuedUsingLocalLicenseID), typeof(int));
                internationallicense.IssueDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordIssueDate), typeof(DateTime));
                internationallicense.ExpirationDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordExpirationDate), typeof(DateTime));
                internationallicense.IsActive =
                  (bool)Convert.ChangeType(reader.GetValue(ordIsActive), typeof(bool));
                internationallicense.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to InternationalLicense Entity:\n   -Error message: {ex.Message}");
                return new InternationalLicense(); ;
            }
            return internationallicense;
        }
        private SqlCommand _PrepareGetAllQuery(InternationalLicensesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enInternationalLicenseField.None && SearchCriteria.SearchBy != enInternationalLicenseField.None)
            {
                string strOrderBy = _GetInternationalLicenseFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetInternationalLicenseFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM InternationalLicenses
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enInternationalLicenseField.None && SearchCriteria.SearchBy != enInternationalLicenseField.None)
            {
                string SearchByColumnName = _GetInternationalLicenseFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM InternationalLicenses
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enInternationalLicenseField.None && SearchCriteria.SearchBy == enInternationalLicenseField.None)
            {
                string OrderByColumnName = _GetInternationalLicenseFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM InternationalLicenses
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM InternationalLicenses
                Order by {_GetInternationalLicenseFieldString(enInternationalLicenseField.InternationalLicenseID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetInternationalLicenseFieldString(enInternationalLicenseField strInternationalLicenseField)
        {
            string strOrderBy = "";
            switch (strInternationalLicenseField)
            {
                case enInternationalLicenseField.InternationalLicenseID:
                    strOrderBy = "InternationalLicenseID";
                    break;
                case enInternationalLicenseField.ApplicationID:
                    strOrderBy = "ApplicationID";
                    break;
                case enInternationalLicenseField.DriverID:
                    strOrderBy = "DriverID";
                    break;
                case enInternationalLicenseField.IssuedUsingLocalLicenseID:
                    strOrderBy = "IssuedUsingLocalLicenseID";
                    break;
                case enInternationalLicenseField.IssueDate:
                    strOrderBy = "IssueDate";
                    break;
                case enInternationalLicenseField.ExpirationDate:
                    strOrderBy = "ExpirationDate";
                    break;
                case enInternationalLicenseField.IsActive:
                    strOrderBy = "IsActive";
                    break;
                case enInternationalLicenseField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                default:
                    strOrderBy = "InternationalLicenseID";
                    break;
            }
            return strOrderBy;
        }
        private List<InternationalLicense> _ExecuteCommandReturnInternationalLicenses(SqlCommand Command)
        {
            List<InternationalLicense> internationallicenses = new List<InternationalLicense>();

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
                            int ordInternationalLicenseID = reader.GetOrdinal("InternationalLicenseID");
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordIssuedUsingLocalLicenseID = reader.GetOrdinal("IssuedUsingLocalLicenseID");
                            int ordIssueDate = reader.GetOrdinal("IssueDate");
                            int ordExpirationDate = reader.GetOrdinal("ExpirationDate");
                            int ordIsActive = reader.GetOrdinal("IsActive");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            while (reader.Read())
                            {
                                internationallicenses.Add(_MapDataReaderToInternationalLicense(reader, ordInternationalLicenseID, ordApplicationID, ordDriverID, ordIssuedUsingLocalLicenseID, ordIssueDate, ordExpirationDate, ordIsActive, ordCreatedByUserID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    internationallicenses = new List<InternationalLicense>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return internationallicenses;
        }
        #endregion
    }
}
