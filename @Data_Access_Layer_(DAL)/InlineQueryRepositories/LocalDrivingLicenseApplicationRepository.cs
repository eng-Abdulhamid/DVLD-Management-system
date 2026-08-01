using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enLocalDrivingLicenseApplicationField
    {
        None = 0,
        LocalDrivingLicenseApplicationID,
        ApplicationID,
        LicenseClassID
    }
    #endregion

    public partial class LocalDrivingLicenseApplicationRepository : ILocalDrivingLicenseApplicationRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllLocalDrivingLicenseApplications()
        {
            string Query = $"SELECT COUNT(*) AS LocalDrivingLicenseApplicationsCount FROM LocalDrivingLicenseApplications";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewLocalDrivingLicenseApplication(LocalDrivingLicenseApplication LocalDrivingLicenseApplicationDeatils)
        {
            string Query =
                $@"INSERT INTO LocalDrivingLicenseApplications(ApplicationID, LicenseClassID)
                   VALUES(@ApplicationID, @LicenseClassID)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationID", (object)LocalDrivingLicenseApplicationDeatils.ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", (object)LocalDrivingLicenseApplicationDeatils.LicenseClassID);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public LocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string Query = $"SELECT TOP 1 * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", (object)LocalDrivingLicenseApplicationID);
            LocalDrivingLicenseApplication localdrivinglicenseapplication = new LocalDrivingLicenseApplication();

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
                            int ordLocalDrivingLicenseApplicationID = reader.GetOrdinal("LocalDrivingLicenseApplicationID");
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordLicenseClassID = reader.GetOrdinal("LicenseClassID");
                            if (reader.Read())
                            {
                                localdrivinglicenseapplication = _MapDataReaderToLocalDrivingLicenseApplication(reader, ordLocalDrivingLicenseApplicationID, ordApplicationID, ordLicenseClassID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    localdrivinglicenseapplication = new LocalDrivingLicenseApplication();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return localdrivinglicenseapplication;
        }
        public bool DeleteLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string Query = $"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@LocalDrivingLicenseApplicationID", (object)LocalDrivingLicenseApplicationID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplication UpdatedLocalDrivingLicenseApplication)
        {
            string Query = $@"UPDATE LocalDrivingLicenseApplications SET 
                ApplicationID=@ApplicationID,
                LicenseClassID=@LicenseClassID
                WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", (object)UpdatedLocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationID", (object)UpdatedLocalDrivingLicenseApplication.ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", (object)UpdatedLocalDrivingLicenseApplication.LicenseClassID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsLocalDrivingLicenseApplicationExistByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string Query = $"SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }


        public List<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationsSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllLocalDrivingLicenseApplicationAtPageSearchBy' operation");
                return new List<LocalDrivingLicenseApplication>();
            }

            return _ExecuteCommandReturnLocalDrivingLicenseApplications(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<LocalDrivingLicenseApplication> GetAllLocalDrivingLicenseApplications()
        {
            string Query = "Select * from LocalDrivingLicenseApplications";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnLocalDrivingLicenseApplications(Command);
        }
        public int GetCountOfLocalDrivingLicenseApplicationsByFilter(LocalDrivingLicenseApplicationsSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enLocalDrivingLicenseApplicationField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetLocalDrivingLicenseApplicationFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS LocalDrivingLicenseApplicationsCount FROM LocalDrivingLicenseApplications
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS LocalDrivingLicenseApplicationsCount FROM LocalDrivingLicenseApplications";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class LocalDrivingLicenseApplicationsSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enLocalDrivingLicenseApplicationField OrderBy { get; set; } = enLocalDrivingLicenseApplicationField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enLocalDrivingLicenseApplicationField SearchBy { get; set; } = enLocalDrivingLicenseApplicationField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private LocalDrivingLicenseApplication _MapDataReaderToLocalDrivingLicenseApplication(SqlDataReader reader, int ordLocalDrivingLicenseApplicationID, int ordApplicationID, int ordLicenseClassID)
        {
            LocalDrivingLicenseApplication localdrivinglicenseapplication = new LocalDrivingLicenseApplication();

            try
            {
                localdrivinglicenseapplication.LocalDrivingLicenseApplicationID =
                  (int)Convert.ChangeType(reader.GetValue(ordLocalDrivingLicenseApplicationID), typeof(int));
                localdrivinglicenseapplication.ApplicationID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicationID), typeof(int));
                localdrivinglicenseapplication.LicenseClassID =
                  (int)Convert.ChangeType(reader.GetValue(ordLicenseClassID), typeof(int));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to LocalDrivingLicenseApplication Entity:\n   -Error message: {ex.Message}");
                return new LocalDrivingLicenseApplication(); ;
            }
            return localdrivinglicenseapplication;
        }
        private SqlCommand _PrepareGetAllQuery(LocalDrivingLicenseApplicationsSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enLocalDrivingLicenseApplicationField.None && SearchCriteria.SearchBy != enLocalDrivingLicenseApplicationField.None)
            {
                string strOrderBy = _GetLocalDrivingLicenseApplicationFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetLocalDrivingLicenseApplicationFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM LocalDrivingLicenseApplications
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enLocalDrivingLicenseApplicationField.None && SearchCriteria.SearchBy != enLocalDrivingLicenseApplicationField.None)
            {
                string SearchByColumnName = _GetLocalDrivingLicenseApplicationFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM LocalDrivingLicenseApplications
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enLocalDrivingLicenseApplicationField.None && SearchCriteria.SearchBy == enLocalDrivingLicenseApplicationField.None)
            {
                string OrderByColumnName = _GetLocalDrivingLicenseApplicationFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM LocalDrivingLicenseApplications
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM LocalDrivingLicenseApplications
                Order by {_GetLocalDrivingLicenseApplicationFieldString(enLocalDrivingLicenseApplicationField.LocalDrivingLicenseApplicationID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetLocalDrivingLicenseApplicationFieldString(enLocalDrivingLicenseApplicationField strLocalDrivingLicenseApplicationField)
        {
            string strOrderBy = "";
            switch (strLocalDrivingLicenseApplicationField)
            {
                case enLocalDrivingLicenseApplicationField.LocalDrivingLicenseApplicationID:
                    strOrderBy = "LocalDrivingLicenseApplicationID";
                    break;
                case enLocalDrivingLicenseApplicationField.ApplicationID:
                    strOrderBy = "ApplicationID";
                    break;
                case enLocalDrivingLicenseApplicationField.LicenseClassID:
                    strOrderBy = "LicenseClassID";
                    break;
                default:
                    strOrderBy = "LocalDrivingLicenseApplicationID";
                    break;
            }
            return strOrderBy;
        }
        private List<LocalDrivingLicenseApplication> _ExecuteCommandReturnLocalDrivingLicenseApplications(SqlCommand Command)
        {
            List<LocalDrivingLicenseApplication> localdrivinglicenseapplications = new List<LocalDrivingLicenseApplication>();

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
                            int ordLocalDrivingLicenseApplicationID = reader.GetOrdinal("LocalDrivingLicenseApplicationID");
                            int ordApplicationID = reader.GetOrdinal("ApplicationID");
                            int ordLicenseClassID = reader.GetOrdinal("LicenseClassID");
                            while (reader.Read())
                            {
                                localdrivinglicenseapplications.Add(_MapDataReaderToLocalDrivingLicenseApplication(reader, ordLocalDrivingLicenseApplicationID, ordApplicationID, ordLicenseClassID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    localdrivinglicenseapplications = new List<LocalDrivingLicenseApplication>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return localdrivinglicenseapplications;
        }
        #endregion
    }
}
