using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enLicenseField
    {
        None = 0,
        LicenseID,
        ApplicationID,
        DriverID,
        LicenseClass,
        IssueDate,
        ExpirationDate,
        Notes,
        PaidFees,
        IsActive,
        IssueReason,
        CreatedByUserID
    }
    #endregion

    public partial class LicenseRepository : ILicenseRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllLicenses()
        {
            string Query = $"SELECT COUNT(*) AS LicensesCount FROM Licenses";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewLicense(License LicenseDeatils)
        {
            string Query =
                $@"INSERT INTO Licenses(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                   VALUES(@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", (object)LicenseDeatils.ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", (object)LicenseDeatils.DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", (object)LicenseDeatils.LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", (object)LicenseDeatils.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", (object)LicenseDeatils.ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", (object)LicenseDeatils.Notes);
            Command.Parameters.AddWithValue("@PaidFees", (object)LicenseDeatils.PaidFees);
            Command.Parameters.AddWithValue("@IsActive", (object)LicenseDeatils.IsActive);
            Command.Parameters.AddWithValue("@IssueReason", (object)LicenseDeatils.IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)LicenseDeatils.CreatedByUserID);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public License FindLicenseByLicenseID(int LicenseID)
        {
            string Query = $"SELECT TOP 1 * FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LicenseID", (object)LicenseID);
            License license = new License();

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
                            int ordLicenseID = reader.GetOrdinal("LicenseID");
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordLicenseClass = reader.GetOrdinal("LicenseClass");
                            int ordIssueDate = reader.GetOrdinal("IssueDate");
                            int ordExpirationDate = reader.GetOrdinal("ExpirationDate");
                            int ordNotes = reader.GetOrdinal("Notes");
                            int ordPaidFees = reader.GetOrdinal("PaidFees");
                            int ordIsActive = reader.GetOrdinal("IsActive");
                            int ordIssueReason = reader.GetOrdinal("IssueReason");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            if (reader.Read())
                            {
                                license = _MapDataReaderToLicense(reader, ordLicenseID, ordApplicationID, ordDriverID, ordLicenseClass, ordIssueDate, ordExpirationDate, ordNotes, ordPaidFees, ordIsActive, ordIssueReason, ordCreatedByUserID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    license = new License();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return license;
        }
        public bool DeleteLicenseByLicenseID(int LicenseID)
        {
            string Query = $"DELETE FROM Licenses WHERE LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@LicenseID", (object)LicenseID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateLicenseByLicenseID(License UpdatedLicense)
        {
            string Query = $@"UPDATE Licenses SET 
                ApplicationID=@ApplicationID,
                DriverID=@DriverID,
                LicenseClass=@LicenseClass,
                IssueDate=@IssueDate,
                ExpirationDate=@ExpirationDate,
                Notes=@Notes,
                PaidFees=@PaidFees,
                IsActive=@IsActive,
                IssueReason=@IssueReason,
                CreatedByUserID=@CreatedByUserID
                WHERE LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LicenseID", (object)UpdatedLicense.LicenseID);
            Command.Parameters.AddWithValue("@ApplicationID", (object)UpdatedLicense.ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", (object)UpdatedLicense.DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", (object)UpdatedLicense.LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", (object)UpdatedLicense.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", (object)UpdatedLicense.ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", (object)UpdatedLicense.Notes);
            Command.Parameters.AddWithValue("@PaidFees", (object)UpdatedLicense.PaidFees);
            Command.Parameters.AddWithValue("@IsActive", (object)UpdatedLicense.IsActive);
            Command.Parameters.AddWithValue("@IssueReason", (object)UpdatedLicense.IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedLicense.CreatedByUserID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsLicenseExistByLicenseID(int LicenseID)
        {
            string Query = $"SELECT 1 FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@LicenseID", LicenseID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }










        public List<License> GetLicenses(LicensesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllLicenseAtPageSearchBy' operation");
                return new List<License>();
            }

            return _ExecuteCommandReturnLicenses(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<License> GetAllLicenses()
        {
            string Query = "Select * from Licenses";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnLicenses(Command);
        }
        public int GetCountOfLicensesByFilter(LicensesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enLicenseField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetLicenseFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS LicensesCount FROM Licenses
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS LicensesCount FROM Licenses";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class LicensesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enLicenseField OrderBy { get; set; } = enLicenseField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enLicenseField SearchBy { get; set; } = enLicenseField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private License _MapDataReaderToLicense(SqlDataReader reader, int ordLicenseID, int ordApplicationID, int ordDriverID, int ordLicenseClass, int ordIssueDate, int ordExpirationDate, int ordNotes, int ordPaidFees, int ordIsActive, int ordIssueReason, int ordCreatedByUserID)
        {
            License license = new License();

            try
            {
                license.LicenseID =
                  (int)Convert.ChangeType(reader.GetValue(ordLicenseID), typeof(int));
                license.ApplicationID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicationID), typeof(int));
                license.DriverID =
                  (int)Convert.ChangeType(reader.GetValue(ordDriverID), typeof(int));
                license.LicenseClass =
                  (int)Convert.ChangeType(reader.GetValue(ordLicenseClass), typeof(int));
                license.IssueDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordIssueDate), typeof(DateTime));
                license.ExpirationDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordExpirationDate), typeof(DateTime));
                if (!reader.IsDBNull(ordNotes))
                {
                    license.Notes = reader[ordNotes].ToString();
                }
                else
                {
                    license.Notes = string.Empty;
                }
                license.PaidFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordPaidFees), typeof(decimal));
                license.IsActive =
                  (bool)Convert.ChangeType(reader.GetValue(ordIsActive), typeof(bool));
                license.IssueReason =
                  (byte)Convert.ChangeType(reader.GetValue(ordIssueReason), typeof(byte));
                license.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to License Entity:\n   -Error message: {ex.Message}");
                return new License(); ;
            }
            return license;
        }
        private SqlCommand _PrepareGetAllQuery(LicensesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enLicenseField.None && SearchCriteria.SearchBy != enLicenseField.None)
            {
                string strOrderBy = _GetLicenseFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetLicenseFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM Licenses
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enLicenseField.None && SearchCriteria.SearchBy != enLicenseField.None)
            {
                string SearchByColumnName = _GetLicenseFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM Licenses
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enLicenseField.None && SearchCriteria.SearchBy == enLicenseField.None)
            {
                string OrderByColumnName = _GetLicenseFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM Licenses
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM Licenses
                Order by {_GetLicenseFieldString(enLicenseField.LicenseID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetLicenseFieldString(enLicenseField strLicenseField)
        {
            string strOrderBy = "";
            switch (strLicenseField)
            {
                case enLicenseField.LicenseID:
                    strOrderBy = "LicenseID";
                    break;
                case enLicenseField.ApplicationID:
                    strOrderBy = "ApplicationID";
                    break;
                case enLicenseField.DriverID:
                    strOrderBy = "DriverID";
                    break;
                case enLicenseField.LicenseClass:
                    strOrderBy = "LicenseClass";
                    break;
                case enLicenseField.IssueDate:
                    strOrderBy = "IssueDate";
                    break;
                case enLicenseField.ExpirationDate:
                    strOrderBy = "ExpirationDate";
                    break;
                case enLicenseField.Notes:
                    strOrderBy = "Notes";
                    break;
                case enLicenseField.PaidFees:
                    strOrderBy = "PaidFees";
                    break;
                case enLicenseField.IsActive:
                    strOrderBy = "IsActive";
                    break;
                case enLicenseField.IssueReason:
                    strOrderBy = "IssueReason";
                    break;
                case enLicenseField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                default:
                    strOrderBy = "LicenseID";
                    break;
            }
            return strOrderBy;
        }
        private List<License> _ExecuteCommandReturnLicenses(SqlCommand Command)
        {
            List<License> licenses = new List<License>();

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
                            int ordLicenseID = reader.GetOrdinal("LicenseID");
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordLicenseClass = reader.GetOrdinal("LicenseClass");
                            int ordIssueDate = reader.GetOrdinal("IssueDate");
                            int ordExpirationDate = reader.GetOrdinal("ExpirationDate");
                            int ordNotes = reader.GetOrdinal("Notes");
                            int ordPaidFees = reader.GetOrdinal("PaidFees");
                            int ordIsActive = reader.GetOrdinal("IsActive");
                            int ordIssueReason = reader.GetOrdinal("IssueReason");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            while (reader.Read())
                            {
                                licenses.Add(_MapDataReaderToLicense(reader, ordLicenseID, ordApplicationID, ordDriverID, ordLicenseClass, ordIssueDate, ordExpirationDate, ordNotes, ordPaidFees, ordIsActive, ordIssueReason, ordCreatedByUserID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    licenses = new List<License>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return licenses;
        }
        #endregion
    }
}
