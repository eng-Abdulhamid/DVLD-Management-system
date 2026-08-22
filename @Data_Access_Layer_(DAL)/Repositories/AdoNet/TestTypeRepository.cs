using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enTestTypeField
    {
        None = 0,
        TestTypeID,
        TestTypeTitle,
        TestTypeDescription,
        TestTypeFees
    }
    #endregion

    public partial class TestTypeRepository : ITestTypeRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllTestTypes()
        {
            string Query = $"SELECT COUNT(*) AS TestTypesCount FROM TestTypes";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewTestType(TestType TestTypeDeatils)
        {
            string Query =
                $@"INSERT INTO TestTypes(TestTypeTitle, TestTypeDescription, TestTypeFees)
                   VALUES(@TestTypeTitle, @TestTypeDescription, @TestTypeFees)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestTypeTitle", (object)TestTypeDeatils.TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", (object)TestTypeDeatils.TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", (object)TestTypeDeatils.TestTypeFees);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public TestType FindTestTypeByTestTypeID(int TestTypeID)
        {
            string Query = $"SELECT TOP 1 * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestTypeID", (object)TestTypeID);
            TestType testtype = new TestType();

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
                            int ordTestTypeID = reader.GetOrdinal("TestTypeID");
                            int ordTestTypeTitle = reader.GetOrdinal("TestTypeTitle");
                            int ordTestTypeDescription = reader.GetOrdinal("TestTypeDescription");
                            int ordTestTypeFees = reader.GetOrdinal("TestTypeFees");
                            if (reader.Read())
                            {
                                testtype = _MapDataReaderToTestType(reader, ordTestTypeID, ordTestTypeTitle, ordTestTypeDescription, ordTestTypeFees);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    testtype = new TestType();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return testtype;
        }
        public bool DeleteTestTypeByTestTypeID(int TestTypeID)
        {
            string Query = $"DELETE FROM TestTypes WHERE TestTypeID=@TestTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@TestTypeID", (object)TestTypeID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateTestTypeByTestTypeID(TestType UpdatedTestType)
        {
            string Query = $@"UPDATE TestTypes SET 
                TestTypeTitle=@TestTypeTitle,
                TestTypeDescription=@TestTypeDescription,
                TestTypeFees=@TestTypeFees
                WHERE TestTypeID=@TestTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestTypeID", (object)UpdatedTestType.TestTypeID);
            Command.Parameters.AddWithValue("@TestTypeTitle", (object)UpdatedTestType.TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", (object)UpdatedTestType.TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", (object)UpdatedTestType.TestTypeFees);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsTestTypeExistByTestTypeID(int TestTypeID)
        {
            string Query = $"SELECT 1 FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@TestTypeID", TestTypeID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }



        public List<TestType> GetTestTypes(TestTypesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllTestTypeAtPageSearchBy' operation");
                return new List<TestType>();
            }

            return _ExecuteCommandReturnTestTypes(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<TestType> GetAllTestTypes()
        {
            string Query = "Select * from TestTypes";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnTestTypes(Command);
        }
        public int GetCountOfTestTypesByFilter(TestTypesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enTestTypeField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetTestTypeFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS TestTypesCount FROM TestTypes
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS TestTypesCount FROM TestTypes";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class TestTypesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enTestTypeField OrderBy { get; set; } = enTestTypeField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enTestTypeField SearchBy { get; set; } = enTestTypeField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private TestType _MapDataReaderToTestType(SqlDataReader reader, int ordTestTypeID, int ordTestTypeTitle, int ordTestTypeDescription, int ordTestTypeFees)
        {
            TestType testtype = new TestType();

            try
            {
                testtype.TestTypeID =
                  (int)Convert.ChangeType(reader.GetValue(ordTestTypeID), typeof(int));
                testtype.TestTypeTitle = reader[ordTestTypeTitle].ToString();
                testtype.TestTypeDescription = reader[ordTestTypeDescription].ToString();
                testtype.TestTypeFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordTestTypeFees), typeof(decimal));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to TestType Entity:\n   -Error message: {ex.Message}");
                return new TestType(); ;
            }
            return testtype;
        }
        private SqlCommand _PrepareGetAllQuery(TestTypesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enTestTypeField.None && SearchCriteria.SearchBy != enTestTypeField.None)
            {
                string strOrderBy = _GetTestTypeFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetTestTypeFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM TestTypes
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enTestTypeField.None && SearchCriteria.SearchBy != enTestTypeField.None)
            {
                string SearchByColumnName = _GetTestTypeFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM TestTypes
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enTestTypeField.None && SearchCriteria.SearchBy == enTestTypeField.None)
            {
                string OrderByColumnName = _GetTestTypeFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM TestTypes
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM TestTypes
                Order by {_GetTestTypeFieldString(enTestTypeField.TestTypeID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetTestTypeFieldString(enTestTypeField strTestTypeField)
        {
            string strOrderBy = "";
            switch (strTestTypeField)
            {
                case enTestTypeField.TestTypeID:
                    strOrderBy = "TestTypeID";
                    break;
                case enTestTypeField.TestTypeTitle:
                    strOrderBy = "TestTypeTitle";
                    break;
                case enTestTypeField.TestTypeDescription:
                    strOrderBy = "TestTypeDescription";
                    break;
                case enTestTypeField.TestTypeFees:
                    strOrderBy = "TestTypeFees";
                    break;
                default:
                    strOrderBy = "TestTypeID";
                    break;
            }
            return strOrderBy;
        }
        private List<TestType> _ExecuteCommandReturnTestTypes(SqlCommand Command)
        {
            List<TestType> testtypes = new List<TestType>();

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
                            int ordTestTypeID = reader.GetOrdinal("TestTypeID");
                            int ordTestTypeTitle = reader.GetOrdinal("TestTypeTitle");
                            int ordTestTypeDescription = reader.GetOrdinal("TestTypeDescription");
                            int ordTestTypeFees = reader.GetOrdinal("TestTypeFees");
                            while (reader.Read())
                            {
                                testtypes.Add(_MapDataReaderToTestType(reader, ordTestTypeID, ordTestTypeTitle, ordTestTypeDescription, ordTestTypeFees));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    testtypes = new List<TestType>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return testtypes;
        }
        #endregion
    }
}
