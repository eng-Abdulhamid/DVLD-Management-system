using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enCountryField
    {
        None = 0,
        CountryID,
        CountryName
    }
    #endregion

    public partial class CountryRepository : ICountryRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllCountries()
        {
            string Query = $"SELECT COUNT(*) AS CountriesCount FROM Countries";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewCountry(Country CountryDeatils)
        {
            string Query =
                $@"INSERT INTO Countries(CountryName)
                   VALUES(@CountryName)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@CountryName", (object)CountryDeatils.CountryName);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public Country FindCountryByCountryID(int CountryID)
        {
            string Query = $"SELECT TOP 1 * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@CountryID", (object)CountryID);
            Country country = new Country();

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
                            int ordCountryID = reader.GetOrdinal("CountryID");
                            int ordCountryName = reader.GetOrdinal("CountryName");
                            if (reader.Read())
                            {
                                country = _MapDataReaderToCountry(reader, ordCountryID, ordCountryName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    country = new Country();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return country;
        }
        public bool DeleteCountryByCountryID(int CountryID)
        {
            string Query = $"DELETE FROM Countries WHERE CountryID=@CountryID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@CountryID", (object)CountryID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateCountryByCountryID(Country UpdatedCountry)
        {
            string Query = $@"UPDATE Countries SET 
                CountryName=@CountryName
                WHERE CountryID=@CountryID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@CountryID", (object)UpdatedCountry.CountryID);
            Command.Parameters.AddWithValue("@CountryName", (object)UpdatedCountry.CountryName);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsCountryExistByCountryID(int CountryID)
        {
            string Query = $"SELECT 1 FROM Countries WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@CountryID", CountryID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }

        public List<Country> GetCountries(CountriesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllCountryAtPageSearchBy' operation");
                return new List<Country>();
            }

            return _ExecuteCommandReturnCountries(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<Country> GetAllCountries()
        {
            string Query = "Select * from Countries";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnCountries(Command);
        }
        public int GetCountOfCountriesByFilter(CountriesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enCountryField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetCountryFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS CountriesCount FROM Countries
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS CountriesCount FROM Countries";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class CountriesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enCountryField OrderBy { get; set; } = enCountryField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enCountryField SearchBy { get; set; } = enCountryField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private Country _MapDataReaderToCountry(SqlDataReader reader, int ordCountryID, int ordCountryName)
        {
            Country country = new Country();

            try
            {
                country.CountryID =
                  (int)Convert.ChangeType(reader.GetValue(ordCountryID), typeof(int));
                country.CountryName = reader[ordCountryName].ToString();
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to Country Entity:\n   -Error message: {ex.Message}");
                return new Country(); ;
            }
            return country;
        }
        private SqlCommand _PrepareGetAllQuery(CountriesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enCountryField.None && SearchCriteria.SearchBy != enCountryField.None)
            {
                string strOrderBy = _GetCountryFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetCountryFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM Countries
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enCountryField.None && SearchCriteria.SearchBy != enCountryField.None)
            {
                string SearchByColumnName = _GetCountryFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM Countries
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enCountryField.None && SearchCriteria.SearchBy == enCountryField.None)
            {
                string OrderByColumnName = _GetCountryFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM Countries
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM Countries
                Order by {_GetCountryFieldString(enCountryField.CountryID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetCountryFieldString(enCountryField strCountryField)
        {
            string strOrderBy = "";
            switch (strCountryField)
            {
                case enCountryField.CountryID:
                    strOrderBy = "CountryID";
                    break;
                case enCountryField.CountryName:
                    strOrderBy = "CountryName";
                    break;
                default:
                    strOrderBy = "CountryID";
                    break;
            }
            return strOrderBy;
        }
        private List<Country> _ExecuteCommandReturnCountries(SqlCommand Command)
        {
            List<Country> countries = new List<Country>();

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
                            int ordCountryID = reader.GetOrdinal("CountryID");
                            int ordCountryName = reader.GetOrdinal("CountryName");
                            while (reader.Read())
                            {
                                countries.Add(_MapDataReaderToCountry(reader, ordCountryID, ordCountryName));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    countries = new List<Country>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return countries;
        }
        #endregion
    }
}
