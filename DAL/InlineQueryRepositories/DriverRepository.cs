using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enDriverField
    {
        None = 0,
        DriverID,
        PersonID,
        CreatedByUserID,
        CreatedDate
    }
    #endregion

    public partial class DriverRepository : IDriverRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllDrivers()
        {
            string Query = $"SELECT COUNT(*) AS DriversCount FROM Drivers";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewDriver(Driver DriverDeatils)
        {
            string Query =
                $@"INSERT INTO Drivers(PersonID, CreatedByUserID, CreatedDate)
                   VALUES(@PersonID, @CreatedByUserID, @CreatedDate)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)DriverDeatils.PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)DriverDeatils.CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", (object)DriverDeatils.CreatedDate);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public Driver FindDriverByDriverID(int DriverID)
        {
            string Query = $"SELECT TOP 1 * FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DriverID", (object)DriverID);
            Driver driver = new Driver();

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
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            int ordCreatedDate = reader.GetOrdinal("CreatedDate");
                            if (reader.Read())
                            {
                                driver = _MapDataReaderToDriver(reader, ordDriverID, ordPersonID, ordCreatedByUserID, ordCreatedDate);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    driver = new Driver();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return driver;
        }
        public bool DeleteDriverByDriverID(int DriverID)
        {
            string Query = $"DELETE FROM Drivers WHERE DriverID=@DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@DriverID", (object)DriverID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateDriverByDriverID(Driver UpdatedDriver)
        {
            string Query = $@"UPDATE Drivers SET 
                PersonID=@PersonID,
                CreatedByUserID=@CreatedByUserID,
                CreatedDate=@CreatedDate
                WHERE DriverID=@DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@DriverID", (object)UpdatedDriver.DriverID);
            Command.Parameters.AddWithValue("@PersonID", (object)UpdatedDriver.PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedDriver.CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", (object)UpdatedDriver.CreatedDate);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsDriverExistByDriverID(int DriverID)
        {
            string Query = $"SELECT 1 FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@DriverID", DriverID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }



        public List<Driver> GetDrivers(DriversSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllDriverAtPageSearchBy' operation");
                return new List<Driver>();
            }

            return _ExecuteCommandReturnDrivers(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<Driver> GetAllDrivers()
        {
            string Query = "Select * from Drivers";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnDrivers(Command);
        }
        public int GetCountOfDriversByFilter(DriversSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enDriverField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetDriverFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS DriversCount FROM Drivers
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS DriversCount FROM Drivers";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class DriversSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enDriverField OrderBy { get; set; } = enDriverField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enDriverField SearchBy { get; set; } = enDriverField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private Driver _MapDataReaderToDriver(SqlDataReader reader, int ordDriverID, int ordPersonID, int ordCreatedByUserID, int ordCreatedDate)
        {
            Driver driver = new Driver();

            try
            {
                driver.DriverID =
                  (int)Convert.ChangeType(reader.GetValue(ordDriverID), typeof(int));
                driver.PersonID =
                  (int)Convert.ChangeType(reader.GetValue(ordPersonID), typeof(int));
                driver.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
                driver.CreatedDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordCreatedDate), typeof(DateTime));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to Driver Entity:\n   -Error message: {ex.Message}");
                return new Driver(); ;
            }
            return driver;
        }
        private SqlCommand _PrepareGetAllQuery(DriversSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enDriverField.None && SearchCriteria.SearchBy != enDriverField.None)
            {
                string strOrderBy = _GetDriverFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetDriverFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM Drivers
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enDriverField.None && SearchCriteria.SearchBy != enDriverField.None)
            {
                string SearchByColumnName = _GetDriverFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM Drivers
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enDriverField.None && SearchCriteria.SearchBy == enDriverField.None)
            {
                string OrderByColumnName = _GetDriverFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM Drivers
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM Drivers
                Order by {_GetDriverFieldString(enDriverField.DriverID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetDriverFieldString(enDriverField strDriverField)
        {
            string strOrderBy = "";
            switch (strDriverField)
            {
                case enDriverField.DriverID:
                    strOrderBy = "DriverID";
                    break;
                case enDriverField.PersonID:
                    strOrderBy = "PersonID";
                    break;
                case enDriverField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                case enDriverField.CreatedDate:
                    strOrderBy = "CreatedDate";
                    break;
                default:
                    strOrderBy = "DriverID";
                    break;
            }
            return strOrderBy;
        }
        private List<Driver> _ExecuteCommandReturnDrivers(SqlCommand Command)
        {
            List<Driver> drivers = new List<Driver>();

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
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            int ordCreatedDate = reader.GetOrdinal("CreatedDate");
                            while (reader.Read())
                            {
                                drivers.Add(_MapDataReaderToDriver(reader, ordDriverID, ordPersonID, ordCreatedByUserID, ordCreatedDate));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    drivers = new List<Driver>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return drivers;
        }
        #endregion
    }
}
