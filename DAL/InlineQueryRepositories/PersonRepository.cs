using DataAccessLayer;
using Entities;
using RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Repositories
{
    #region Enums
    public enum enPersonField
    {
        None = 0,
        PersonID,
        NationalNo,
        FirstName,
        SecondName,
        ThirdName,
        LastName,
        DateOfBirth,
        Gendor,
        Address,
        Phone,
        Email,
        NationalityCountryID,
        ImagePath
    }
    #endregion

    public partial class PersonRepository : IPersonRepository
    {
        #region Main CRUD Operations
        public int GetCountOfAllPeople()
        {
            string Query = $"SELECT COUNT(*) AS PeopleCount FROM People";
            SqlCommand Command = new SqlCommand(Query);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        public int AddNewPerson(Person PersonDeatils)
        {
            string Query =
                $@"INSERT INTO People(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                   VALUES(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@NationalNo", (object)PersonDeatils.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", (object)PersonDeatils.FirstName);
            Command.Parameters.AddWithValue("@SecondName", (object)PersonDeatils.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", (object)PersonDeatils.ThirdName);
            Command.Parameters.AddWithValue("@LastName", (object)PersonDeatils.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", (object)PersonDeatils.DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", (object)PersonDeatils.Gendor);
            Command.Parameters.AddWithValue("@Address", (object)PersonDeatils.Address);
            Command.Parameters.AddWithValue("@Phone", (object)PersonDeatils.Phone);
            Command.Parameters.AddWithValue("@Email", (object)PersonDeatils.Email);
            Command.Parameters.AddWithValue("@NationalityCountryID", (object)PersonDeatils.NationalityCountryID);
            Command.Parameters.AddWithValue("@ImagePath", (object)PersonDeatils.ImagePath);
            return DAMethods._ExecuteScalarReturnInt(Command);
        }

        public Person FindPersonByPersonID(int PersonID)
        {
            string Query = $"SELECT TOP 1 * FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)PersonID);
            Person person = new Person();

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
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordNationalNo = reader.GetOrdinal("NationalNo");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordSecondName = reader.GetOrdinal("SecondName");
                            int ordThirdName = reader.GetOrdinal("ThirdName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordDateOfBirth = reader.GetOrdinal("DateOfBirth");
                            int ordGendor = reader.GetOrdinal("Gendor");
                            int ordAddress = reader.GetOrdinal("Address");
                            int ordPhone = reader.GetOrdinal("Phone");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordNationalityCountryID = reader.GetOrdinal("NationalityCountryID");
                            int ordImagePath = reader.GetOrdinal("ImagePath");
                            if (reader.Read())
                            {
                                person = _MapDataReaderToPerson(reader, ordPersonID, ordNationalNo, ordFirstName, ordSecondName, ordThirdName, ordLastName, ordDateOfBirth, ordGendor, ordAddress, ordPhone, ordEmail, ordNationalityCountryID, ordImagePath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    person = new Person();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return person;
        }
        public bool DeletePersonByPersonID(int PersonID)
        {
            string Query = $"DELETE FROM People WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@PersonID", (object)PersonID);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdatePersonByPersonID(Person UpdatedPerson)
        {
            string Query = $@"UPDATE People SET 
                NationalNo=@NationalNo,
                FirstName=@FirstName,
                SecondName=@SecondName,
                ThirdName=@ThirdName,
                LastName=@LastName,
                DateOfBirth=@DateOfBirth,
                Gendor=@Gendor,
                Address=@Address,
                Phone=@Phone,
                Email=@Email,
                NationalityCountryID=@NationalityCountryID,
                ImagePath=@ImagePath
                WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)UpdatedPerson.PersonID);
            Command.Parameters.AddWithValue("@NationalNo", (object)UpdatedPerson.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", (object)UpdatedPerson.FirstName);
            Command.Parameters.AddWithValue("@SecondName", (object)UpdatedPerson.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", (object)UpdatedPerson.ThirdName);
            Command.Parameters.AddWithValue("@LastName", (object)UpdatedPerson.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", (object)UpdatedPerson.DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", (object)UpdatedPerson.Gendor);
            Command.Parameters.AddWithValue("@Address", (object)UpdatedPerson.Address);
            Command.Parameters.AddWithValue("@Phone", (object)UpdatedPerson.Phone);
            Command.Parameters.AddWithValue("@Email", (object)UpdatedPerson.Email);
            Command.Parameters.AddWithValue("@NationalityCountryID", (object)UpdatedPerson.NationalityCountryID);
            Command.Parameters.AddWithValue("@ImagePath", (object)UpdatedPerson.ImagePath);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsPersonExistByPersonID(int PersonID)
        {
            string Query = $"SELECT 1 FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@PersonID", PersonID);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }

        public Person FindPersonByNationalNo(string NationalNo)
        {
            string Query = $"SELECT TOP 1 * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@NationalNo", (object)NationalNo);
            Person person = new Person();

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
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordNationalNo = reader.GetOrdinal("NationalNo");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordSecondName = reader.GetOrdinal("SecondName");
                            int ordThirdName = reader.GetOrdinal("ThirdName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordDateOfBirth = reader.GetOrdinal("DateOfBirth");
                            int ordGendor = reader.GetOrdinal("Gendor");
                            int ordAddress = reader.GetOrdinal("Address");
                            int ordPhone = reader.GetOrdinal("Phone");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordNationalityCountryID = reader.GetOrdinal("NationalityCountryID");
                            int ordImagePath = reader.GetOrdinal("ImagePath");
                            if (reader.Read())
                            {
                                person = _MapDataReaderToPerson(reader, ordPersonID, ordNationalNo, ordFirstName, ordSecondName, ordThirdName, ordLastName, ordDateOfBirth, ordGendor, ordAddress, ordPhone, ordEmail, ordNationalityCountryID, ordImagePath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    person = new Person();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return person;
        }
        public bool DeletePersonByNationalNo(string NationalNo)
        {
            string Query = $"DELETE FROM People WHERE NationalNo=@NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@NationalNo", (object)NationalNo);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool UpdatePersonByNationalNo(Person UpdatedPerson)
        {
            string Query = $@"UPDATE People SET 
                PersonID=@PersonID,
                FirstName=@FirstName,
                SecondName=@SecondName,
                ThirdName=@ThirdName,
                LastName=@LastName,
                DateOfBirth=@DateOfBirth,
                Gendor=@Gendor,
                Address=@Address,
                Phone=@Phone,
                Email=@Email,
                NationalityCountryID=@NationalityCountryID,
                ImagePath=@ImagePath
                WHERE NationalNo=@NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)UpdatedPerson.PersonID);
            Command.Parameters.AddWithValue("@NationalNo", (object)UpdatedPerson.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", (object)UpdatedPerson.FirstName);
            Command.Parameters.AddWithValue("@SecondName", (object)UpdatedPerson.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", (object)UpdatedPerson.ThirdName);
            Command.Parameters.AddWithValue("@LastName", (object)UpdatedPerson.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", (object)UpdatedPerson.DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", (object)UpdatedPerson.Gendor);
            Command.Parameters.AddWithValue("@Address", (object)UpdatedPerson.Address);
            Command.Parameters.AddWithValue("@Phone", (object)UpdatedPerson.Phone);
            Command.Parameters.AddWithValue("@Email", (object)UpdatedPerson.Email);
            Command.Parameters.AddWithValue("@NationalityCountryID", (object)UpdatedPerson.NationalityCountryID);
            Command.Parameters.AddWithValue("@ImagePath", (object)UpdatedPerson.ImagePath);
            return DAMethods._ExecuteCommandReturnRowAffected(Command) > 0;
        }
        public bool IsPersonExistByNationalNo(string NationalNo)
        {
            string Query = $"SELECT 1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@NationalNo", NationalNo);
            return DAMethods._ExecuteCommandReturnBoolean(Command);
        }











        public List<Person> GetPeople(PeopleSearchCriteria SearchCriteria)
        {
            if (SearchCriteria.PageNumber < 0 || SearchCriteria.PageSize < 0)
            {
                Logs.AppendLog(Logs.enType.Error, "SearchCriteria.PageNumber or SearchCriteria.PageSize is invalid (<= 0). Cannot execute 'GetAllPersonAtPageSearchBy' operation");
                return new List<Person>();
            }

            return _ExecuteCommandReturnPeople(_PrepareGetAllQuery(SearchCriteria));
        }
        public List<Person> GetAllPeople()
        {
            string Query = "Select * from People";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteCommandReturnPeople(Command);
        }
        public int GetCountOfPeopleByFilter(PeopleSearchCriteria SearchCriteria)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.SearchBy != enPersonField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetPersonFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT COUNT(*) AS PeopleCount FROM People
                Where {SearchByColumnName} LIKE @pattern";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else
            {
                Command.CommandText =
                $@"SELECT COUNT(*) AS PeopleCount FROM People";
            }
            return DAMethods._ExecuteScalarReturnInt(Command);
        }
        #endregion
        #region Search Criteria
        public class PeopleSearchCriteria
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public enPersonField OrderBy { get; set; } = enPersonField.None;
            public enSorting Sorting { get; set; } = enSorting.Ascending;
            public enPersonField SearchBy { get; set; } = enPersonField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private Person _MapDataReaderToPerson(SqlDataReader reader, int ordPersonID, int ordNationalNo, int ordFirstName, int ordSecondName, int ordThirdName, int ordLastName, int ordDateOfBirth, int ordGendor, int ordAddress, int ordPhone, int ordEmail, int ordNationalityCountryID, int ordImagePath)
        {
            Person person = new Person();

            try
            {
                person.PersonID =
                  (int)Convert.ChangeType(reader.GetValue(ordPersonID), typeof(int));
                person.NationalNo = reader[ordNationalNo].ToString();
                person.FirstName = reader[ordFirstName].ToString();
                person.SecondName = reader[ordSecondName].ToString();
                if (!reader.IsDBNull(ordThirdName))
                {
                    person.ThirdName = reader[ordThirdName].ToString();
                }
                else
                {
                    person.ThirdName = string.Empty;
                }
                person.LastName = reader[ordLastName].ToString();
                person.DateOfBirth =
                  (DateTime)Convert.ChangeType(reader.GetValue(ordDateOfBirth), typeof(DateTime));
                person.Gendor =
                  (Convert.ToByte(reader.GetValue(ordGendor)) == 1) ? enGendor.Male : (Convert.ToByte(reader.GetValue(ordGendor)) == 2 ? enGendor.Female : enGendor.Unkown);
                person.Address = reader[ordAddress].ToString();
                person.Phone = reader[ordPhone].ToString();
                if (!reader.IsDBNull(ordEmail))
                {
                    person.Email = reader[ordEmail].ToString();
                }
                else
                {
                    person.Email = string.Empty;
                }
                person.NationalityCountryID =
                  (int)Convert.ChangeType(reader.GetValue(ordNationalityCountryID), typeof(int));
                if (!reader.IsDBNull(ordImagePath))
                {
                    person.ImagePath = reader[ordImagePath].ToString();
                }
                else
                {
                    person.ImagePath = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] There was error occured when casting data reader to Person Entity:\n   -Error message: {ex.Message}");
                return new Person(); ;
            }
            return person;
        }
        private SqlCommand _PrepareGetAllQuery(PeopleSearchCriteria SearchCriteria)
        {
            int offset = (SearchCriteria.PageNumber > 0) ? ((SearchCriteria.PageNumber - 1) * SearchCriteria.PageSize) : 0;
            string strSorting = DAMethods._GetSortingString(SearchCriteria.Sorting);

            SqlCommand Command = new SqlCommand();
            if (SearchCriteria.OrderBy != enPersonField.None && SearchCriteria.SearchBy != enPersonField.None)
            {
                string strOrderBy = _GetPersonFieldString(SearchCriteria.OrderBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetPersonFieldString(SearchCriteria.SearchBy);
                Command.CommandText =
                $@"SELECT * FROM People
                Where {SearchByColumnName} LIKE @pattern
                Order by {strOrderBy} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);
            }
            else if (SearchCriteria.OrderBy == enPersonField.None && SearchCriteria.SearchBy != enPersonField.None)
            {
                string SearchByColumnName = _GetPersonFieldString(SearchCriteria.SearchBy);
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                Command.CommandText =
                $@"SELECT * FROM People
                Where {SearchByColumnName} LIKE @pattern
                Order by {SearchByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
                Command.Parameters.AddWithValue("@pattern", LikePattern);

            }
            else if (SearchCriteria.OrderBy != enPersonField.None && SearchCriteria.SearchBy == enPersonField.None)
            {
                string OrderByColumnName = _GetPersonFieldString(SearchCriteria.OrderBy);
                Command.CommandText =
                $@"SELECT * FROM People
                Order by {OrderByColumnName} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            else
            {
                Command.CommandText =
                $@"SELECT * FROM People
                Order by {_GetPersonFieldString(enPersonField.PersonID)} {strSorting}
                OFFSET @offset ROWS
                FETCH NEXT @Size ROWS ONLY";
            }
            Command.Parameters.AddWithValue("@Size", SearchCriteria.PageSize);
            Command.Parameters.AddWithValue("@offset", offset);
            return Command;
        }
        private string _GetPersonFieldString(enPersonField strPersonField)
        {
            string strOrderBy = "";
            switch (strPersonField)
            {
                case enPersonField.PersonID:
                    strOrderBy = "PersonID";
                    break;
                case enPersonField.NationalNo:
                    strOrderBy = "NationalNo";
                    break;
                case enPersonField.FirstName:
                    strOrderBy = "FirstName";
                    break;
                case enPersonField.SecondName:
                    strOrderBy = "SecondName";
                    break;
                case enPersonField.ThirdName:
                    strOrderBy = "ThirdName";
                    break;
                case enPersonField.LastName:
                    strOrderBy = "LastName";
                    break;
                case enPersonField.DateOfBirth:
                    strOrderBy = "DateOfBirth";
                    break;
                case enPersonField.Gendor:
                    strOrderBy = "Gendor";
                    break;
                case enPersonField.Address:
                    strOrderBy = "Address";
                    break;
                case enPersonField.Phone:
                    strOrderBy = "Phone";
                    break;
                case enPersonField.Email:
                    strOrderBy = "Email";
                    break;
                case enPersonField.NationalityCountryID:
                    strOrderBy = "NationalityCountryID";
                    break;
                case enPersonField.ImagePath:
                    strOrderBy = "ImagePath";
                    break;
                default:
                    strOrderBy = "PersonID";
                    break;
            }
            return strOrderBy;
        }
        private List<Person> _ExecuteCommandReturnPeople(SqlCommand Command)
        {
            List<Person> people = new List<Person>();

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
                            int ordPersonID = reader.GetOrdinal("PersonID");
                            int ordNationalNo = reader.GetOrdinal("NationalNo");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordSecondName = reader.GetOrdinal("SecondName");
                            int ordThirdName = reader.GetOrdinal("ThirdName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordDateOfBirth = reader.GetOrdinal("DateOfBirth");
                            int ordGendor = reader.GetOrdinal("Gendor");
                            int ordAddress = reader.GetOrdinal("Address");
                            int ordPhone = reader.GetOrdinal("Phone");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordNationalityCountryID = reader.GetOrdinal("NationalityCountryID");
                            int ordImagePath = reader.GetOrdinal("ImagePath");
                            while (reader.Read())
                            {
                                people.Add(_MapDataReaderToPerson(reader, ordPersonID, ordNationalNo, ordFirstName, ordSecondName, ordThirdName, ordLastName, ordDateOfBirth, ordGendor, ordAddress, ordPhone, ordEmail, ordNationalityCountryID, ordImagePath));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    people = new List<Person>();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }
            return people;
        }
        #endregion
    }
}
