using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enTestAppointmentField
    {
        None = 0,
        TestAppointmentID,
        TestTypeID,
        LocalDrivingLicenseApplicationID,
        AppointmentDate,
        PaidFees,
        CreatedByUserID,
        IsLocked
    }
    #endregion

    public partial class TestAppointmentRepository : ITestAppointmentRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllTestAppointments()
        {
            string Query = $"SELECT COUNT(*) AS TestAppointmentsCount FROM TestAppointments";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewTestAppointment(TestAppointment TestAppointmentDeatils)
        {
            string Query =
                $@"INSERT INTO TestAppointments(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                   VALUES(@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestTypeID", (object)TestAppointmentDeatils.TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", (object)TestAppointmentDeatils.LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", (object)TestAppointmentDeatils.AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", (object)TestAppointmentDeatils.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)TestAppointmentDeatils.CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", (object)TestAppointmentDeatils.IsLocked);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public TestAppointment FindTestAppointmentByTestAppointmentID(int TestAppointmentID)
        {
            string Query = $"SELECT TOP 1 * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestAppointmentID", (object)TestAppointmentID);
            TestAppointment testappointment = new TestAppointment();

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
                            int ordTestAppointmentID = reader.GetOrdinal("TestAppointmentID");
                            int ordTestTypeID = reader.GetOrdinal("TestTypeID");
                            int ordLocalDrivingLicenseApplicationID = reader.GetOrdinal("LocalDrivingLicenseApplicationID");
                            int ordAppointmentDate = reader.GetOrdinal("AppointmentDate");
                            int ordPaidFees = reader.GetOrdinal("PaidFees");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            int ordIsLocked = reader.GetOrdinal("IsLocked");
                            if (reader.Read())
                            {
                                testappointment = _MapDataReaderToTestAppointment(reader, ordTestAppointmentID, ordTestTypeID, ordLocalDrivingLicenseApplicationID, ordAppointmentDate, ordPaidFees, ordCreatedByUserID, ordIsLocked);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    testappointment = new TestAppointment();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return testappointment;
        }
        public bool DeleteTestAppointmentByTestAppointmentID(int TestAppointmentID)
        {
            string Query = $"DELETE FROM TestAppointments WHERE TestAppointmentID=@TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@TestAppointmentID", (object)TestAppointmentID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateTestAppointmentByTestAppointmentID(TestAppointment UpdatedTestAppointment)
        {
            string Query = $@"UPDATE TestAppointments SET 
                TestTypeID=@TestTypeID,
                LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,
                AppointmentDate=@AppointmentDate,
                PaidFees=@PaidFees,
                CreatedByUserID=@CreatedByUserID,
                IsLocked=@IsLocked
                WHERE TestAppointmentID=@TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@TestAppointmentID", (object)UpdatedTestAppointment.TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", (object)UpdatedTestAppointment.TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", (object)UpdatedTestAppointment.LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", (object)UpdatedTestAppointment.AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", (object)UpdatedTestAppointment.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", (object)UpdatedTestAppointment.CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", (object)UpdatedTestAppointment.IsLocked);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsTestAppointmentExistByTestAppointmentID(int TestAppointmentID)
        {
            string Query = $"SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@TestAppointmentID", TestAppointmentID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }






        public List<TestAppointment> GetTestAppointments(TestAppointmentsSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllTestAppointmentAtPageSearchBy' operation");
                return new List<TestAppointment>();
            }

            return _ExecuteCommandReturnTestAppointments(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<TestAppointment> GetAllTestAppointments()
        {
            string Query = "Select * from TestAppointments";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnTestAppointments(Command);
        }
        public int GetCountOfTestAppointmentsByFilter(TestAppointmentsSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enTestAppointmentField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetTestAppointmentFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS TestAppointmentsCount FROM TestAppointments
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS TestAppointmentsCount FROM TestAppointments";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class TestAppointmentsSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enTestAppointmentField OrderBy { get; set; } = enTestAppointmentField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enTestAppointmentField SearchBy { get; set; } = enTestAppointmentField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private TestAppointment _MapDataReaderToTestAppointment(SqlDataReader reader, int ordTestAppointmentID, int ordTestTypeID, int ordLocalDrivingLicenseApplicationID, int ordAppointmentDate, int ordPaidFees, int ordCreatedByUserID, int ordIsLocked)
        {
            TestAppointment testappointment = new TestAppointment();

            try
            {
                testappointment.TestAppointmentID =
                  (int)Convert.ChangeType(reader.GetValue(ordTestAppointmentID), typeof(int));
                testappointment.TestTypeID =
                  (int)Convert.ChangeType(reader.GetValue(ordTestTypeID), typeof(int));
                testappointment.LocalDrivingLicenseApplicationID =
                  (int)Convert.ChangeType(reader.GetValue(ordLocalDrivingLicenseApplicationID), typeof(int));
                testappointment.AppointmentDate =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordAppointmentDate), typeof(DateTime));
                testappointment.PaidFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordPaidFees), typeof(decimal));
                testappointment.CreatedByUserID =
                  (int)Convert.ChangeType(reader.GetValue(ordCreatedByUserID), typeof(int));
                testappointment.IsLocked =
                  (bool)Convert.ChangeType(reader.GetValue(ordIsLocked), typeof(bool));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to TestAppointment Entity:\n   -Error message: {ex.Message}");
                return new TestAppointment(); ;
            }
            return testappointment;
        }
        private SqlCommand _PrepareGetAllQuery(TestAppointmentsSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enTestAppointmentField.None && SearchCriteria.SearchBy != enTestAppointmentField.None)
            {
                string strOrderBy = _GetTestAppointmentFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetTestAppointmentFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM TestAppointments
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enTestAppointmentField.None && SearchCriteria.SearchBy != enTestAppointmentField.None)
            {
                string SearchByColumnName = _GetTestAppointmentFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM TestAppointments
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enTestAppointmentField.None && SearchCriteria.SearchBy == enTestAppointmentField.None)
            {
                string OrderByColumnName = _GetTestAppointmentFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM TestAppointments
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM TestAppointments
                Order by {_GetTestAppointmentFieldString(enTestAppointmentField.TestAppointmentID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetTestAppointmentFieldString(enTestAppointmentField strTestAppointmentField)
        {
            string strOrderBy = "";
            switch (strTestAppointmentField)
            {
                case enTestAppointmentField.TestAppointmentID:
                    strOrderBy = "TestAppointmentID";
                    break;
                case enTestAppointmentField.TestTypeID:
                    strOrderBy = "TestTypeID";
                    break;
                case enTestAppointmentField.LocalDrivingLicenseApplicationID:
                    strOrderBy = "LocalDrivingLicenseApplicationID";
                    break;
                case enTestAppointmentField.AppointmentDate:
                    strOrderBy = "AppointmentDate";
                    break;
                case enTestAppointmentField.PaidFees:
                    strOrderBy = "PaidFees";
                    break;
                case enTestAppointmentField.CreatedByUserID:
                    strOrderBy = "CreatedByUserID";
                    break;
                case enTestAppointmentField.IsLocked:
                    strOrderBy = "IsLocked";
                    break;
                default:
                    strOrderBy = "TestAppointmentID";
                    break;
            }
            return strOrderBy;
        }
        private List<TestAppointment> _ExecuteCommandReturnTestAppointments(SqlCommand Command)
        {
            List<TestAppointment> testappointments = new List<TestAppointment>();

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
                            int ordTestAppointmentID = reader.GetOrdinal("TestAppointmentID");
                            int ordTestTypeID = reader.GetOrdinal("TestTypeID");
                            int ordLocalDrivingLicenseApplicationID = reader.GetOrdinal("LocalDrivingLicenseApplicationID");
                            int ordAppointmentDate = reader.GetOrdinal("AppointmentDate");
                            int ordPaidFees = reader.GetOrdinal("PaidFees");
                            int ordCreatedByUserID = reader.GetOrdinal("CreatedByUserID");
                            int ordIsLocked = reader.GetOrdinal("IsLocked");
                            while (reader.Read())
                            {
                                testappointments.Add(_MapDataReaderToTestAppointment(reader, ordTestAppointmentID, ordTestTypeID, ordLocalDrivingLicenseApplicationID, ordAppointmentDate, ordPaidFees, ordCreatedByUserID, ordIsLocked));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    testappointments = new List<TestAppointment>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return testappointments;
        }
        #endregion
    }
}
