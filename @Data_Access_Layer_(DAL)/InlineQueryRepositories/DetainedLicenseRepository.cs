using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enDetainedLicenseField
    {
        None = 0,
        DetainID,
        LicenseID,
        DetainDate,
        FineFees,
        CreatedByUserID,
        IsReleased,
        ReleaseDate,
        ReleasedByUserID,
        ReleaseApplicationID
    }
    #endregion

    public partial class DetainedLicenseRepository : IDetainedLicenseRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllDetainedLicenses()
        {
            string Query = $"SELECT COUNT(*) AS DetainedLicensesCount FROM DetainedLicenses";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewDetainedLicense(DetainedLicense DetainedLicenseDeatils)
        {
            string Query =
                $@"INSERT INTO DetainedLicenses(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                   VALUES(@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LicenseID", (object)DetainedLicenseDeatils.LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", (object)DetainedLicenseDeatils.DetainDate);
            Command.Parameters.AddWithValue("@FineFees", (object)DetainedLicenseDeatils.FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)DetainedLicenseDeatils.CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", (object)DetainedLicenseDeatils.IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", (object)DetainedLicenseDeatils.ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", (object)DetainedLicenseDeatils.ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", (object)DetainedLicenseDeatils.ReleaseApplicationID);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public DetainedLicense FindDetainedLicenseByDetainID(int DetainID)
        {
            string Query = $"SELECT TOP 1 * FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DetainID", (object)DetainID);
            DetainedLicense detainedlicense = new DetainedLicense();

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
                            int ordDetainID = reader.GetOrdinal("DetainID");
                            int ordLicenseID = reader.GetOrdinal("LicenseID");
                            int ordDetainDate = reader.GetOrdinal("DetainDate");
                            int ordFineFees = reader.GetOrdinal("FineFees");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            int ordIsReleased = reader.GetOrdinal("IsReleased");
                            int ordReleaseDate = reader.GetOrdinal("ReleaseDate");
                            int ordReleasedByUserID = reader.GetOrdinal("ReleasedByUserID");
                            int ordReleaseApplicationID = reader.GetOrdinal("ReleaseApplicationID");
                            if (reader.Read())
                            {
                                detainedlicense = _MapDataReaderToDetainedLicense(reader, ordDetainID, ordLicenseID, ordDetainDate, ordFineFees, ordCreatedByUserID, ordIsReleased, ordReleaseDate, ordReleasedByUserID, ordReleaseApplicationID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    detainedlicense = new DetainedLicense();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return detainedlicense;
        }
        public bool DeleteDetainedLicenseByDetainID(int DetainID)
        {
            string Query = $"DELETE FROM DetainedLicenses WHERE DetainID=@DetainID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@DetainID", (object)DetainID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateDetainedLicenseByDetainID(DetainedLicense UpdatedDetainedLicense)
        {
            string Query = $@"UPDATE DetainedLicenses SET 
                LicenseID=@LicenseID,
                DetainDate=@DetainDate,
                FineFees=@FineFees,
                CreatedByUserID=@CreatedByUserID,
                IsReleased=@IsReleased,
                ReleaseDate=@ReleaseDate,
                ReleasedByUserID=@ReleasedByUserID,
                ReleaseApplicationID=@ReleaseApplicationID
                WHERE DetainID=@DetainID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DetainID", (object)UpdatedDetainedLicense.DetainID);
            Command.Parameters.AddWithValue("@LicenseID", (object)UpdatedDetainedLicense.LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", (object)UpdatedDetainedLicense.DetainDate);
            Command.Parameters.AddWithValue("@FineFees", (object)UpdatedDetainedLicense.FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedDetainedLicense.CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", (object)UpdatedDetainedLicense.IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", (object)UpdatedDetainedLicense.ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", (object)UpdatedDetainedLicense.ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", (object)UpdatedDetainedLicense.ReleaseApplicationID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsDetainedLicenseExistByDetainID(int DetainID)
        {
            string Query = $"SELECT 1 FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@DetainID", DetainID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }








        public List<DetainedLicense> GetDetainedLicenses(DetainedLicensesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllDetainedLicenseAtPageSearchBy' operation");
                return new List<DetainedLicense>();
            }

            return _ExecuteCommandReturnDetainedLicenses(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<DetainedLicense> GetAllDetainedLicenses()
        {
            string Query = "Select * from DetainedLicenses";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnDetainedLicenses(Command);
        }
        public int GetCountOfDetainedLicensesByFilter(DetainedLicensesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enDetainedLicenseField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetDetainedLicenseFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS DetainedLicensesCount FROM DetainedLicenses
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS DetainedLicensesCount FROM DetainedLicenses";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class DetainedLicensesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enDetainedLicenseField OrderBy { get; set; } = enDetainedLicenseField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enDetainedLicenseField SearchBy { get; set; } = enDetainedLicenseField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private DetainedLicense _MapDataReaderToDetainedLicense(SqlDataReader reader, int ordDetainID, int ordLicenseID, int ordDetainDate, int ordFineFees, int ordCreatedByUserID, int ordIsReleased, int ordReleaseDate, int ordReleasedByUserID, int ordReleaseApplicationID)
        {
            DetainedLicense detainedlicense = new DetainedLicense();

            try
            {
                detainedlicense.DetainID =
                  (int)Convert.ChangeType(reader.GetValue(ordDetainID), typeof(int));
                detainedlicense.LicenseID =
                  (int)Convert.ChangeType(reader.GetValue(ordLicenseID), typeof(int));
                detainedlicense.DetainDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordDetainDate), typeof(DateTime));
                detainedlicense.FineFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordFineFees), typeof(decimal));
                detainedlicense.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
                detainedlicense.IsReleased =
                  (bool)Convert.ChangeType(reader.GetValue(ordIsReleased), typeof(bool));
                if (!reader.IsDBNull(ordReleaseDate))
                {

                    detainedlicense.ReleaseDate =
                        (DateTime)Convert.ChangeType(reader.GetValue(ordReleaseDate), typeof(DateTime));

                }
                else
                {
                    detainedlicense.ReleaseDate = DateTime.MinValue;
                }
                if (!reader.IsDBNull(ordReleasedByUserID))
                {

                    detainedlicense.ReleasedByUserID =
                        (int)Convert.ChangeType(reader.GetValue(ordReleasedByUserID), typeof(int));

                }
                else
                {
                    detainedlicense.ReleasedByUserID = -1;
                }
                if (!reader.IsDBNull(ordReleaseApplicationID))
                {

                    detainedlicense.ReleaseApplicationID =
                        (int)Convert.ChangeType(reader.GetValue(ordReleaseApplicationID), typeof(int));

                }
                else
                {
                    detainedlicense.ReleaseApplicationID = -1;
                }
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to DetainedLicense Entity:\n   -Error message: {ex.Message}");
                return new DetainedLicense(); ;
            }
            return detainedlicense;
        }
        private SqlCommand _PrepareGetAllQuery(DetainedLicensesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enDetainedLicenseField.None && SearchCriteria.SearchBy != enDetainedLicenseField.None)
            {
                string strOrderBy = _GetDetainedLicenseFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetDetainedLicenseFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM DetainedLicenses
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enDetainedLicenseField.None && SearchCriteria.SearchBy != enDetainedLicenseField.None)
            {
                string SearchByColumnName = _GetDetainedLicenseFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM DetainedLicenses
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enDetainedLicenseField.None && SearchCriteria.SearchBy == enDetainedLicenseField.None)
            {
                string OrderByColumnName = _GetDetainedLicenseFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM DetainedLicenses
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM DetainedLicenses
                Order by {_GetDetainedLicenseFieldString(enDetainedLicenseField.DetainID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetDetainedLicenseFieldString(enDetainedLicenseField strDetainedLicenseField)
        {
            string strOrderBy = "";
            switch (strDetainedLicenseField)
            {
                case enDetainedLicenseField.DetainID:
                    strOrderBy = "DetainID";
                    break;
                case enDetainedLicenseField.LicenseID:
                    strOrderBy = "LicenseID";
                    break;
                case enDetainedLicenseField.DetainDate:
                    strOrderBy = "DetainDate";
                    break;
                case enDetainedLicenseField.FineFees:
                    strOrderBy = "FineFees";
                    break;
                case enDetainedLicenseField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                case enDetainedLicenseField.IsReleased:
                    strOrderBy = "IsReleased";
                    break;
                case enDetainedLicenseField.ReleaseDate:
                    strOrderBy = "ReleaseDate";
                    break;
                case enDetainedLicenseField.ReleasedByUserID:
                    strOrderBy = "ReleasedByUserID";
                    break;
                case enDetainedLicenseField.ReleaseApplicationID:
                    strOrderBy = "ReleaseApplicationID";
                    break;
                default:
                    strOrderBy = "DetainID";
                    break;
            }
            return strOrderBy;
        }
        private List<DetainedLicense> _ExecuteCommandReturnDetainedLicenses(SqlCommand Command)
        {
            List<DetainedLicense> detainedlicenses = new List<DetainedLicense>();

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
                            int ordDetainID = reader.GetOrdinal("DetainID");
                            int ordLicenseID = reader.GetOrdinal("LicenseID");
                            int ordDetainDate = reader.GetOrdinal("DetainDate");
                            int ordFineFees = reader.GetOrdinal("FineFees");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            int ordIsReleased = reader.GetOrdinal("IsReleased");
                            int ordReleaseDate = reader.GetOrdinal("ReleaseDate");
                            int ordReleasedByUserID = reader.GetOrdinal("ReleasedByUserID");
                            int ordReleaseApplicationID = reader.GetOrdinal("ReleaseApplicationID");
                            while (reader.Read())
                            {
                                detainedlicenses.Add(_MapDataReaderToDetainedLicense(reader, ordDetainID, ordLicenseID, ordDetainDate, ordFineFees, ordCreatedByUserID, ordIsReleased, ordReleaseDate, ordReleasedByUserID, ordReleaseApplicationID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    detainedlicenses = new List<DetainedLicense>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return detainedlicenses;
        }
        #endregion
    }
}
