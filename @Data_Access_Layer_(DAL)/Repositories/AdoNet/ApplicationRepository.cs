using Entities;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enApplicationField
    {
        None = 0,
        ApplicationID,
        ApplicantPersonID,
        ApplicationDate,
        ApplicationTypeID,
        ApplicationStatus,
        LastStatusDate,
        PaidFees,
        CreatedByUserID
    }
    #endregion

    public partial class ApplicationRepository : IApplicationRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllApplications()
        {
            string Query = $"SELECT COUNT(*) AS ApplicationsCount FROM Applications";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewApplication(Application ApplicationDeatils)
        {
            string Query =
                $@"INSERT INTO Applications(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                   VALUES(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicantPersonID", (object)ApplicationDeatils.ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", (object)ApplicationDeatils.ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", (object)ApplicationDeatils.ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", (object)ApplicationDeatils.ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", (object)ApplicationDeatils.LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", (object)ApplicationDeatils.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)ApplicationDeatils.CreatedByUserID);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public Application FindApplicationByApplicationID(int ApplicationID)
        {
            string Query = $"SELECT TOP 1 * FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", (object)ApplicationID);
            Application application = new Application();

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
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordApplicantPersonID = reader.GetOrdinal("ApplicantPersonID");
                            int ordApplicationDate = reader.GetOrdinal("ApplicationDate");
                            int ordApplicationTypeID = reader.GetOrdinal("ApplicationTypeID");
                            int ordApplicationStatus = reader.GetOrdinal("ApplicationStatus");
                            int ordLastStatusDate = reader.GetOrdinal("LastStatusDate");
                            int ordPaidFees = reader.GetOrdinal("PaidFees");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            if (reader.Read())
                            {
                                application = _MapDataReaderToApplication(reader, ordApplicationID, ordApplicantPersonID, ordApplicationDate, ordApplicationTypeID, ordApplicationStatus, ordLastStatusDate, ordPaidFees, ordCreatedByUserID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    application = new Application();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return application;
        }
        public bool DeleteApplicationByApplicationID(int ApplicationID)
        {
            string Query = $"DELETE FROM Applications WHERE ApplicationID=@ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@ApplicationID", (object)ApplicationID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateApplicationByApplicationID(Application UpdatedApplication)
        {
            string Query = $@"UPDATE Applications SET 
                ApplicantPersonID=@ApplicantPersonID,
                ApplicationDate=@ApplicationDate,
                ApplicationTypeID=@ApplicationTypeID,
                ApplicationStatus=@ApplicationStatus,
                LastStatusDate=@LastStatusDate,
                PaidFees=@PaidFees,
                CreatedByUserID=@CreatedByUserID
                WHERE ApplicationID=@ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", (object)UpdatedApplication.ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", (object)UpdatedApplication.ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", (object)UpdatedApplication.ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", (object)UpdatedApplication.ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", (object)UpdatedApplication.ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", (object)UpdatedApplication.LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", (object)UpdatedApplication.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedApplication.CreatedByUserID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsApplicationExistByApplicationID(int ApplicationID)
        {
            string Query = $"SELECT 1 FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@ApplicationID", ApplicationID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }







        public List<Application> GetApplications(ApplicationsSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllApplicationAtPageSearchBy' operation");
                return new List<Application>();
            }

            return _ExecuteCommandReturnApplications(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<Application> GetAllApplications()
        {
            string Query = "Select * from Applications";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnApplications(Command);
        }
        public int GetCountOfApplicationsByFilter(ApplicationsSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enApplicationField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetApplicationFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS ApplicationsCount FROM Applications
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS ApplicationsCount FROM Applications";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class ApplicationsSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enApplicationField OrderBy { get; set; } = enApplicationField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enApplicationField SearchBy { get; set; } = enApplicationField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private Application _MapDataReaderToApplication(SqlDataReader reader, int ordApplicationID, int ordApplicantPersonID, int ordApplicationDate, int ordApplicationTypeID, int ordApplicationStatus, int ordLastStatusDate, int ordPaidFees, int ordCreatedByUserID)
        {
            Application application = new Application();

            try
            {
                application.ApplicationID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicationID), typeof(int));
                application.ApplicantPersonID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicantPersonID), typeof(int));
                application.ApplicationDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordApplicationDate), typeof(DateTime));
                application.ApplicationTypeID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicationTypeID), typeof(int));
                application.ApplicationStatus =
                  (byte)Convert.ChangeType(reader.GetValue(ordApplicationStatus), typeof(byte));
                application.LastStatusDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordLastStatusDate), typeof(DateTime));
                application.PaidFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordPaidFees), typeof(decimal));
                application.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to Application Entity:\n   -Error message: {ex.Message}");
                return new Application(); ;
            }
            return application;
        }
        private SqlCommand _PrepareGetAllQuery(ApplicationsSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enApplicationField.None && SearchCriteria.SearchBy != enApplicationField.None)
            {
                string strOrderBy = _GetApplicationFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetApplicationFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM Applications
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enApplicationField.None && SearchCriteria.SearchBy != enApplicationField.None)
            {
                string SearchByColumnName = _GetApplicationFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM Applications
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enApplicationField.None && SearchCriteria.SearchBy == enApplicationField.None)
            {
                string OrderByColumnName = _GetApplicationFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM Applications
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM Applications
                Order by {_GetApplicationFieldString(enApplicationField.ApplicationID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetApplicationFieldString(enApplicationField strApplicationField)
        {
            string strOrderBy = "";
            switch (strApplicationField)
            {
                case enApplicationField.ApplicationID:
                    strOrderBy = "ApplicationID";
                    break;
                case enApplicationField.ApplicantPersonID:
                    strOrderBy = "ApplicantPersonID";
                    break;
                case enApplicationField.ApplicationDate:
                    strOrderBy = "ApplicationDate";
                    break;
                case enApplicationField.ApplicationTypeID:
                    strOrderBy = "ApplicationTypeID";
                    break;
                case enApplicationField.ApplicationStatus:
                    strOrderBy = "ApplicationStatus";
                    break;
                case enApplicationField.LastStatusDate:
                    strOrderBy = "LastStatusDate";
                    break;
                case enApplicationField.PaidFees:
                    strOrderBy = "PaidFees";
                    break;
                case enApplicationField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                default:
                    strOrderBy = "ApplicationID";
                    break;
            }
            return strOrderBy;
        }
        private List<Application> _ExecuteCommandReturnApplications(SqlCommand Command)
        {
            List<Application> applications = new List<Application>();

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
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordApplicantPersonID = reader.GetOrdinal("ApplicantPersonID");
                            int ordApplicationDate = reader.GetOrdinal("ApplicationDate");
                            int ordApplicationTypeID = reader.GetOrdinal("ApplicationTypeID");
                            int ordApplicationStatus = reader.GetOrdinal("ApplicationStatus");
                            int ordLastStatusDate = reader.GetOrdinal("LastStatusDate");
                            int ordPaidFees = reader.GetOrdinal("PaidFees");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            while (reader.Read())
                            {
                                applications.Add(_MapDataReaderToApplication(reader, ordApplicationID, ordApplicantPersonID, ordApplicationDate, ordApplicationTypeID, ordApplicationStatus, ordLastStatusDate, ordPaidFees, ordCreatedByUserID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    applications = new List<Application>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return applications;
        }
        #endregion
    }
}
