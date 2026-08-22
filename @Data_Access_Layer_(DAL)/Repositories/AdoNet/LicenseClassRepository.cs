using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enLicenseClassField
    {
        None = 0,
        LicenseClassID,
        ClassName,
        ClassDescription,
        MinimumAllowedAge,
        DefaultValidityLength,
        ClassFees
    }
    #endregion

    public partial class LicenseClassRepository : ILicenseClassRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllLicenseClasses()
        {
            string Query = $"SELECT COUNT(*) AS LicenseClassesCount FROM LicenseClasses";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewLicenseClass(LicenseClass LicenseClassDeatils)
        {
            string Query =
                $@"INSERT INTO LicenseClasses(ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                   VALUES(@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@ClassName", (object)LicenseClassDeatils.ClassName);
            Command.Parameters.AddWithValue("@ClassDescription", (object)LicenseClassDeatils.ClassDescription);
            Command.Parameters.AddWithValue("@MinimumAllowedAge", (object)LicenseClassDeatils.MinimumAllowedAge);
            Command.Parameters.AddWithValue("@DefaultValidityLength", (object)LicenseClassDeatils.DefaultValidityLength);
            Command.Parameters.AddWithValue("@ClassFees", (object)LicenseClassDeatils.ClassFees);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public LicenseClass FindLicenseClassByLicenseClassID(int LicenseClassID)
        {
            string Query = $"SELECT TOP 1 * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LicenseClassID", (object)LicenseClassID);
            LicenseClass licenseclass = new LicenseClass();

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
                            int ordLicenseClassID = reader.GetOrdinal("LicenseClassID");
                            int ordClassName = reader.GetOrdinal("ClassName");
                            int ordClassDescription = reader.GetOrdinal("ClassDescription");
                            int ordMinimumAllowedAge = reader.GetOrdinal("MinimumAllowedAge");
                            int ordDefaultValidityLength = reader.GetOrdinal("DefaultValidityLength");
                            int ordClassFees = reader.GetOrdinal("ClassFees");
                            if (reader.Read())
                            {
                                licenseclass = _MapDataReaderToLicenseClass(reader, ordLicenseClassID, ordClassName, ordClassDescription, ordMinimumAllowedAge, ordDefaultValidityLength, ordClassFees);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    licenseclass = new LicenseClass();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return licenseclass;
        }
        public bool DeleteLicenseClassByLicenseClassID(int LicenseClassID)
        {
            string Query = $"DELETE FROM LicenseClasses WHERE LicenseClassID=@LicenseClassID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@LicenseClassID", (object)LicenseClassID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdateLicenseClassByLicenseClassID(LicenseClass UpdatedLicenseClass)
        {
            string Query = $@"UPDATE LicenseClasses SET 
                ClassName=@ClassName,
                ClassDescription=@ClassDescription,
                MinimumAllowedAge=@MinimumAllowedAge,
                DefaultValidityLength=@DefaultValidityLength,
                ClassFees=@ClassFees
                WHERE LicenseClassID=@LicenseClassID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@LicenseClassID", (object)UpdatedLicenseClass.LicenseClassID);
            Command.Parameters.AddWithValue("@ClassName", (object)UpdatedLicenseClass.ClassName);
            Command.Parameters.AddWithValue("@ClassDescription", (object)UpdatedLicenseClass.ClassDescription);
            Command.Parameters.AddWithValue("@MinimumAllowedAge", (object)UpdatedLicenseClass.MinimumAllowedAge);
            Command.Parameters.AddWithValue("@DefaultValidityLength", (object)UpdatedLicenseClass.DefaultValidityLength);
            Command.Parameters.AddWithValue("@ClassFees", (object)UpdatedLicenseClass.ClassFees);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsLicenseClassExistByLicenseClassID(int LicenseClassID)
        {
            string Query = $"SELECT 1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@LicenseClassID", LicenseClassID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }





        public List<LicenseClass> GetLicenseClasses(LicenseClassesSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllLicenseClassAtPageSearchBy' operation");
                return new List<LicenseClass>();
            }

            return _ExecuteCommandReturnLicenseClasses(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<LicenseClass> GetAllLicenseClasses()
        {
            string Query = "Select * from LicenseClasses";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnLicenseClasses(Command);
        }
        public int GetCountOfLicenseClassesByFilter(LicenseClassesSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enLicenseClassField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetLicenseClassFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS LicenseClassesCount FROM LicenseClasses
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS LicenseClassesCount FROM LicenseClasses";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class LicenseClassesSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enLicenseClassField OrderBy { get; set; } = enLicenseClassField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enLicenseClassField SearchBy { get; set; } = enLicenseClassField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private LicenseClass _MapDataReaderToLicenseClass(SqlDataReader reader, int ordLicenseClassID, int ordClassName, int ordClassDescription, int ordMinimumAllowedAge, int ordDefaultValidityLength, int ordClassFees)
        {
            LicenseClass licenseclass = new LicenseClass();

            try
            {
                licenseclass.LicenseClassID =
                  (int)Convert.ChangeType(reader.GetValue(ordLicenseClassID), typeof(int));
                licenseclass.ClassName = reader[ordClassName].ToString();
                licenseclass.ClassDescription = reader[ordClassDescription].ToString();
                licenseclass.MinimumAllowedAge =
                  (byte)Convert.ChangeType(reader.GetValue(ordMinimumAllowedAge), typeof(byte));
                licenseclass.DefaultValidityLength =
                  (byte)Convert.ChangeType(reader.GetValue(ordDefaultValidityLength), typeof(byte));
                licenseclass.ClassFees =
                  (decimal)Convert.ChangeType(reader.GetValue(ordClassFees), typeof(decimal));
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to LicenseClass Entity:\n   -Error message: {ex.Message}");
                return new LicenseClass(); ;
            }
            return licenseclass;
        }
        private SqlCommand _PrepareGetAllQuery(LicenseClassesSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enLicenseClassField.None && SearchCriteria.SearchBy != enLicenseClassField.None)
            {
                string strOrderBy = _GetLicenseClassFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetLicenseClassFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM LicenseClasses
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enLicenseClassField.None && SearchCriteria.SearchBy != enLicenseClassField.None)
            {
                string SearchByColumnName = _GetLicenseClassFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM LicenseClasses
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enLicenseClassField.None && SearchCriteria.SearchBy == enLicenseClassField.None)
            {
                string OrderByColumnName = _GetLicenseClassFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM LicenseClasses
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM LicenseClasses
                Order by {_GetLicenseClassFieldString(enLicenseClassField.LicenseClassID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetLicenseClassFieldString(enLicenseClassField strLicenseClassField)
        {
            string strOrderBy = "";
            switch (strLicenseClassField)
            {
                case enLicenseClassField.LicenseClassID:
                    strOrderBy = "LicenseClassID";
                    break;
                case enLicenseClassField.ClassName:
                    strOrderBy = "ClassName";
                    break;
                case enLicenseClassField.ClassDescription:
                    strOrderBy = "ClassDescription";
                    break;
                case enLicenseClassField.MinimumAllowedAge:
                    strOrderBy = "MinimumAllowedAge";
                    break;
                case enLicenseClassField.DefaultValidityLength:
                    strOrderBy = "DefaultValidityLength";
                    break;
                case enLicenseClassField.ClassFees:
                    strOrderBy = "ClassFees";
                    break;
                default:
                    strOrderBy = "LicenseClassID";
                    break;
            }
            return strOrderBy;
        }
        private List<LicenseClass> _ExecuteCommandReturnLicenseClasses(SqlCommand Command)
        {
            List<LicenseClass> licenseclasses = new List<LicenseClass>();

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
                            int ordLicenseClassID = reader.GetOrdinal("LicenseClassID");
                            int ordClassName = reader.GetOrdinal("ClassName");
                            int ordClassDescription = reader.GetOrdinal("ClassDescription");
                            int ordMinimumAllowedAge = reader.GetOrdinal("MinimumAllowedAge");
                            int ordDefaultValidityLength = reader.GetOrdinal("DefaultValidityLength");
                            int ordClassFees = reader.GetOrdinal("ClassFees");
                            while (reader.Read())
                            {
                                licenseclasses.Add(_MapDataReaderToLicenseClass(reader, ordLicenseClassID, ordClassName, ordClassDescription, ordMinimumAllowedAge, ordDefaultValidityLength, ordClassFees));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    licenseclasses = new List<LicenseClass>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return licenseclasses;
        }
        #endregion
    }
}
