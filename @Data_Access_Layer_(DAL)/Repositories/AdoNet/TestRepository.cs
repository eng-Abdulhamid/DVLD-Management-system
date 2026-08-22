using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enTestField
    {
        None = 0,
        TestID,
        TestAppointmentID,
        TestResult,
        Notes,
        CreatedByUserID
    }
    #endregion

    public partial class TestRepository : ITestRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllTests()
        {
            string Query = $"SELECT COUNT(*) AS TestsCount FROM Tests";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewTest(Test TestDeatils)
        {
            string Query =
                $@"INSERT INTO Tests(TestAppointmentID, TestResult, Notes, CreatedByUserID)
                   VALUES(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestAppointmentID", (object)TestDeatils.TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", (object)TestDeatils.TestResult);
            Command.Parameters.AddWithValue("@Notes", (object)TestDeatils.Notes);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)TestDeatils.CreatedByUserID);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public Test FindTestByTestID(int TestID)
        {
            string Query = $"SELECT TOP 1 * FROM Tests WHERE TestID = @TestID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestID", (object)TestID);
            Test test = new Test();

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
                            int ordTestID = reader.GetOrdinal("TestID");
                            int ordTestAppointmentID = reader.GetOrdinal("TestAppointmentID");
                            int ordTestResult = reader.GetOrdinal("TestResult");
                            int ordNotes = reader.GetOrdinal("Notes");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            if (reader.Read())
                            {
                                test = _MapDataReaderToTest(reader, ordTestID, ordTestAppointmentID, ordTestResult, ordNotes, ordCreatedByUserID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    test = new Test();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return test;
        }
        public bool DeleteTestByTestID(int TestID)
        {
            string Query = $"DELETE FROM Tests WHERE TestID=@TestID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@TestID", (object)TestID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateTestByTestID(Test UpdatedTest)
        {
            string Query = $@"UPDATE Tests SET 
                TestAppointmentID=@TestAppointmentID,
                TestResult=@TestResult,
                Notes=@Notes,
                CreatedByUserID=@CreatedByUserID
                WHERE TestID=@TestID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestID", (object)UpdatedTest.TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", (object)UpdatedTest.TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", (object)UpdatedTest.TestResult);
            Command.Parameters.AddWithValue("@Notes", (object)UpdatedTest.Notes);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedTest.CreatedByUserID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsTestExistByTestID(int TestID)
        {
            string Query = $"SELECT 1 FROM Tests WHERE TestID = @TestID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@TestID", TestID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }




        public List<Test> GetTests(TestsSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllTestAtPageSearchBy' operation");
                return new List<Test>();
            }

            return _ExecuteCommandReturnTests(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<Test> GetAllTests()
        {
            string Query = "Select * from Tests";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnTests(Command);
        }
        public int GetCountOfTestsByFilter(TestsSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enTestField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetTestFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS TestsCount FROM Tests
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS TestsCount FROM Tests";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class TestsSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enTestField OrderBy { get; set; } = enTestField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enTestField SearchBy { get; set; } = enTestField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private Test _MapDataReaderToTest(SqlDataReader reader, int ordTestID, int ordTestAppointmentID, int ordTestResult, int ordNotes, int ordCreatedByUserID)
        {
            Test test = new Test();

            try
            {
                test.TestID =
                  (int)Convert.ChangeType(reader.GetValue(ordTestID), typeof(int));
                test.TestAppointmentID =
                  (int)Convert.ChangeType(reader.GetValue(ordTestAppointmentID), typeof(int));
                test.TestResult =
                  (bool)Convert.ChangeType(reader.GetValue(ordTestResult), typeof(bool));
                if (!reader.IsDBNull(ordNotes))
                {
                    test.Notes = reader[ordNotes].ToString();
                }
                else
                {
                    test.Notes = string.Empty;
                }
                test.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to Test Entity:\n   -Error message: {ex.Message}");
                return new Test(); ;
            }
            return test;
        }
        private SqlCommand _PrepareGetAllQuery(TestsSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enTestField.None && SearchCriteria.SearchBy != enTestField.None)
            {
                string strOrderBy = _GetTestFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetTestFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM Tests
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enTestField.None && SearchCriteria.SearchBy != enTestField.None)
            {
                string SearchByColumnName = _GetTestFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM Tests
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enTestField.None && SearchCriteria.SearchBy == enTestField.None)
            {
                string OrderByColumnName = _GetTestFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM Tests
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM Tests
                Order by {_GetTestFieldString(enTestField.TestID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetTestFieldString(enTestField strTestField)
        {
            string strOrderBy = "";
            switch (strTestField)
            {
                case enTestField.TestID:
                    strOrderBy = "TestID";
                    break;
                case enTestField.TestAppointmentID:
                    strOrderBy = "TestAppointmentID";
                    break;
                case enTestField.TestResult:
                    strOrderBy = "TestResult";
                    break;
                case enTestField.Notes:
                    strOrderBy = "Notes";
                    break;
                case enTestField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                default:
                    strOrderBy = "TestID";
                    break;
            }
            return strOrderBy;
        }
        private List<Test> _ExecuteCommandReturnTests(SqlCommand Command)
        {
            List<Test> tests = new List<Test>();

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
                            int ordTestID = reader.GetOrdinal("TestID");
                            int ordTestAppointmentID = reader.GetOrdinal("TestAppointmentID");
                            int ordTestResult = reader.GetOrdinal("TestResult");
                            int ordNotes = reader.GetOrdinal("Notes");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            while (reader.Read())
                            {
                                tests.Add(_MapDataReaderToTest(reader, ordTestID, ordTestAppointmentID, ordTestResult, ordNotes, ordCreatedByUserID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    tests = new List<Test>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return tests;
        }
        #endregion
    }
}
