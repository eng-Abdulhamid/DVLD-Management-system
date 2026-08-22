using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enApplicationTypeField
    {
        None = 0,
        ApplicationTypeID,
        ApplicationTypeTitle,
        ApplicationFees
    }
    #endregion

    public partial class ApplicationTypeRepository : IApplicationTypeRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllApplicationTypes()
        {
            string Query = $"SELECT COUNT(*) AS ApplicationTypesCount FROM ApplicationTypes";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewApplicationType(ApplicationType ApplicationTypeDeatils)
        {
            string Query =
                $@"INSERT INTO ApplicationTypes(ApplicationTypeTitle, ApplicationFees)
                   VALUES(@ApplicationTypeTitle, @ApplicationFees)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", (object)ApplicationTypeDeatils.ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", (object)ApplicationTypeDeatils.ApplicationFees);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public ApplicationType FindApplicationTypeByApplicationTypeID(int ApplicationTypeID)
        {
            string Query = $"SELECT TOP 1 * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationTypeID", (object)ApplicationTypeID);
            ApplicationType applicationtype = new ApplicationType();

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
                            int ordApplicationTypeID = reader.GetOrdinal("ApplicationTypeID");
                            int ordApplicationTypeTitle = reader.GetOrdinal("ApplicationTypeTitle");
                            int ordApplicationFees = reader.GetOrdinal("ApplicationFees");
                            if (reader.Read())
                            {
                                applicationtype = _MapDataReaderToApplicationType(reader, ordApplicationTypeID, ordApplicationTypeTitle, ordApplicationFees);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    applicationtype = new ApplicationType();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return applicationtype;
        }
        public bool DeleteApplicationTypeByApplicationTypeID(int ApplicationTypeID)
        {
            string Query = $"DELETE FROM ApplicationTypes WHERE ApplicationTypeID=@ApplicationTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@ApplicationTypeID", (object)ApplicationTypeID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateApplicationTypeByApplicationTypeID(ApplicationType UpdatedApplicationType)
        {
            string Query = $@"UPDATE ApplicationTypes SET 
                ApplicationTypeTitle=@ApplicationTypeTitle,
                ApplicationFees=@ApplicationFees
                WHERE ApplicationTypeID=@ApplicationTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ApplicationTypeID", (object)UpdatedApplicationType.ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", (object)UpdatedApplicationType.ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", (object)UpdatedApplicationType.ApplicationFees);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsApplicationTypeExistByApplicationTypeID(int ApplicationTypeID)
        {
            string Query = $"SELECT 1 FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@ApplicationTypeID", ApplicationTypeID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }


        public List<ApplicationType> GetApplicationTypes(ApplicationTypesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllApplicationTypeAtPageSearchBy' operation");
                return new List<ApplicationType>();
            }

            return _ExecuteCommandReturnApplicationTypes(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<ApplicationType> GetAllApplicationTypes()
        {
            string Query = "Select * from ApplicationTypes";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnApplicationTypes(Command);
        }
        public int GetCountOfApplicationTypesByFilter(ApplicationTypesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enApplicationTypeField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetApplicationTypeFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS ApplicationTypesCount FROM ApplicationTypes
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS ApplicationTypesCount FROM ApplicationTypes";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class ApplicationTypesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enApplicationTypeField OrderBy { get; set; } = enApplicationTypeField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enApplicationTypeField SearchBy { get; set; } = enApplicationTypeField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private ApplicationType _MapDataReaderToApplicationType(SqlDataReader reader, int ordApplicationTypeID, int ordApplicationTypeTitle, int ordApplicationFees)
        {
            ApplicationType applicationtype = new ApplicationType();

            try
            {
                applicationtype.ApplicationTypeID =
                  (int)Convert.ChangeType(reader.GetValue(ordApplicationTypeID), typeof(int));
                applicationtype.ApplicationTypeTitle = reader[ordApplicationTypeTitle].ToString();
                applicationtype.ApplicationFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordApplicationFees), typeof(decimal));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to ApplicationType Entity:\n   -Error message: {ex.Message}");
                return new ApplicationType(); ;
            }
            return applicationtype;
        }
        private SqlCommand _PrepareGetAllQuery(ApplicationTypesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enApplicationTypeField.None && SearchCriteria.SearchBy != enApplicationTypeField.None)
            {
                string strOrderBy = _GetApplicationTypeFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetApplicationTypeFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM ApplicationTypes
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enApplicationTypeField.None && SearchCriteria.SearchBy != enApplicationTypeField.None)
            {
                string SearchByColumnName = _GetApplicationTypeFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM ApplicationTypes
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enApplicationTypeField.None && SearchCriteria.SearchBy == enApplicationTypeField.None)
            {
                string OrderByColumnName = _GetApplicationTypeFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM ApplicationTypes
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM ApplicationTypes
                Order by {_GetApplicationTypeFieldString(enApplicationTypeField.ApplicationTypeID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetApplicationTypeFieldString(enApplicationTypeField strApplicationTypeField)
        {
            string strOrderBy = "";
            switch (strApplicationTypeField)
            {
                case enApplicationTypeField.ApplicationTypeID:
                    strOrderBy = "ApplicationTypeID";
                    break;
                case enApplicationTypeField.ApplicationTypeTitle:
                    strOrderBy = "ApplicationTypeTitle";
                    break;
                case enApplicationTypeField.ApplicationFees:
                    strOrderBy = "ApplicationFees";
                    break;
                default:
                    strOrderBy = "ApplicationTypeID";
                    break;
            }
            return strOrderBy;
        }
        private List<ApplicationType> _ExecuteCommandReturnApplicationTypes(SqlCommand Command)
        {
            List<ApplicationType> applicationtypes = new List<ApplicationType>();

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
                            int ordApplicationTypeID = reader.GetOrdinal("ApplicationTypeID");
                            int ordApplicationTypeTitle = reader.GetOrdinal("ApplicationTypeTitle");
                            int ordApplicationFees = reader.GetOrdinal("ApplicationFees");
                            while (reader.Read())
                            {
                                applicationtypes.Add(_MapDataReaderToApplicationType(reader, ordApplicationTypeID, ordApplicationTypeTitle, ordApplicationFees));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    applicationtypes = new List<ApplicationType>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return applicationtypes;
        }
        #endregion
    }
}
