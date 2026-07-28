using DataAccessLayer;
using Entities;
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
        Gender,
        Address,
        Phone,
        Email,
        NationalityCountryID,
        ImagePath
    }
    #endregion

    public partial class PersonRepository
    {
        #region Main CRUD Operations
        public int AddNewPerson(Person PersonDeatils)
        {
            string Query =
                $@"INSERT INTO People(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                   VALUES(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
                   Select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@NationalNo", (object)PersonDeatils.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", (object)PersonDeatils.FirstName);
            Command.Parameters.AddWithValue("@SecondName", (object)PersonDeatils.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", (object)PersonDeatils.ThirdName);
            Command.Parameters.AddWithValue("@LastName", (object)PersonDeatils.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", (object)PersonDeatils.DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", (object)PersonDeatils.Gender);
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
                            int ordGender = reader.GetOrdinal("Gender");
                            int ordAddress = reader.GetOrdinal("Address");
                            int ordPhone = reader.GetOrdinal("Phone");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordNationalityCountryID = reader.GetOrdinal("NationalityCountryID");
                            int ordImagePath = reader.GetOrdinal("ImagePath");
                            if (reader.Read())
                            {
                                person = _MapDataReaderToPerson(reader, ordPersonID, ordNationalNo, ordFirstName, ordSecondName, ordThirdName, ordLastName, ordDateOfBirth, ordGender, ordAddress, ordPhone, ordEmail, ordNationalityCountryID, ordImagePath);
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
                Gender=@Gender,
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
            Command.Parameters.AddWithValue("@Gender", (object)UpdatedPerson.Gender);
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
                            int ordGender = reader.GetOrdinal("Gender");
                            int ordAddress = reader.GetOrdinal("Address");
                            int ordPhone = reader.GetOrdinal("Phone");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordNationalityCountryID = reader.GetOrdinal("NationalityCountryID");
                            int ordImagePath = reader.GetOrdinal("ImagePath");
                            if (reader.Read())
                            {
                                person = _MapDataReaderToPerson(reader, ordPersonID, ordNationalNo, ordFirstName, ordSecondName, ordThirdName, ordLastName, ordDateOfBirth, ordGender, ordAddress, ordPhone, ordEmail, ordNationalityCountryID, ordImagePath);
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
                Gender=@Gender,
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
            Command.Parameters.AddWithValue("@Gender", (object)UpdatedPerson.Gender);
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
        public int GetPeopleCount(PeopleSearchCriteria SearchCriteria = null)
        {
            SqlCommand Command = new SqlCommand();
            if (SearchCriteria == null)
            {
                string Query = $"SELECT COUNT(*) AS PeopleCount FROM People";
                Command = new SqlCommand(Query);
                return DAMethods._ExecuteScalarReturnInt(Command);
            }
            if (SearchCriteria.FilterBy != enPersonField.None)
            {
                string LikePattern = DAMethods._GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);
                string SearchByColumnName = _GetPersonFieldString(SearchCriteria.FilterBy);
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
        public List<Person> GetPeople(PeopleSearchCriteria SearchCriteria = null)
        { 
            if (SearchCriteria == null)
            {
                string Query = "Select * from People";
                SqlCommand Command = new SqlCommand(Query);
                return _ExecuteCommandReturnPeople(Command);
            }
            return _ExecuteCommandReturnPeople(_PrepareSQLCommand(SearchCriteria));
        }

        public class PeopleSearchCriteria
        {
            public enGender Gender { get; set; } = enGender.Both;
            public enPersonField FilterBy { get; set; } = enPersonField.None;
            public enSearchType SearchType { get; set; } = enSearchType.None;
            public string SearchText { get; set; } = string.Empty;
        }
        #endregion
        #region Private Methods
        private Person _MapDataReaderToPerson(
            SqlDataReader reader,
            int ordPersonID,
            int ordNationalNo,
            int ordFirstName,
            int ordSecondName,
            int ordThirdName,
            int ordLastName,
            int ordDateOfBirth,
            int ordGender,
            int ordAddress,
            int ordPhone,
            int ordEmail,
            int ordNationalityCountryID,
            int ordImagePath)
        {
            Person person = new Person();

            try
            {
                person.PersonID = reader.GetInt32(ordPersonID);
                person.NationalNo = reader.GetString(ordNationalNo);
                person.FirstName = reader.GetString(ordFirstName);
                person.SecondName = reader.GetString(ordSecondName);

                person.ThirdName = reader.IsDBNull(ordThirdName) ? string.Empty : reader.GetString(ordThirdName);
                person.LastName = reader.GetString(ordLastName);
                person.DateOfBirth = reader.GetDateTime(ordDateOfBirth);

                byte GenderValue = Convert.ToByte(reader.GetValue(ordGender));
                person.Gender = (GenderValue == 1) ? enGender.Male : ((GenderValue == 2) ? enGender.Female : enGender.Both);

                person.Address = reader.GetString(ordAddress);
                person.Phone = reader.GetString(ordPhone);

                person.Email = reader.IsDBNull(ordEmail) ? string.Empty : reader.GetString(ordEmail);

                person.NationalityCountryID = reader.GetInt32(ordNationalityCountryID);

                person.ImagePath = reader.IsDBNull(ordImagePath) ? string.Empty : reader.GetString(ordImagePath);
            }
            catch (Exception ex)
            {
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Error occurred while mapping SqlDataReader to Person Entity:\n - Message: {ex.Message}");
                return null; 
            }

            return person;
        }
        private string _GetPatternSearchString(enSearchType SearchType, string SearchText)
        {
            if (string.IsNullOrEmpty(SearchText)) return "%";
            string LikePattern = SearchText;
            switch (SearchType)
            {
                case enSearchType.Contain:
                    LikePattern = "%" + (string.IsNullOrEmpty(SearchText) ? "" : SearchText) + "%";
                    break;
                case enSearchType.StartWith:
                    LikePattern = (string.IsNullOrEmpty(SearchText) ? "" : SearchText) + "%";
                    break;
                case enSearchType.EndWith:
                    LikePattern = "%" + (string.IsNullOrEmpty(SearchText) ? "" : SearchText);
                    break;
                case enSearchType.None:
                default:
                    LikePattern = SearchText;
                    break;
            }
            return LikePattern;
        }

        private SqlCommand _PrepareSQLCommand(PeopleSearchCriteria SearchCriteria)
        {
            SqlCommand command = new SqlCommand();
            List<string> whereClauses = new List<string>();

            if (SearchCriteria.FilterBy != enPersonField.None)
            {
                string searchByColumnName = _GetPersonFieldString(SearchCriteria.FilterBy);
                string likePattern = _GetPatternSearchString(SearchCriteria.SearchType, SearchCriteria.SearchText);

                whereClauses.Add($"{searchByColumnName} LIKE @pattern");
                command.Parameters.AddWithValue("@pattern", likePattern);
            }

            if (SearchCriteria.Gender != enGender.Both)
            {
                whereClauses.Add("Gender = @gender");
                command.Parameters.AddWithValue("@gender", (byte)SearchCriteria.Gender);
            }

            string query = "SELECT * FROM People";

            if (whereClauses.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", whereClauses);
            }

            query += " ORDER BY PersonID DESC";

            command.CommandText = query;
            return command;
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
                case enPersonField.Gender:
                    strOrderBy = "Gender";
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
                            int ordGender = reader.GetOrdinal("Gender");
                            int ordAddress = reader.GetOrdinal("Address");
                            int ordPhone = reader.GetOrdinal("Phone");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordNationalityCountryID = reader.GetOrdinal("NationalityCountryID");
                            int ordImagePath = reader.GetOrdinal("ImagePath");
                            while (reader.Read())
                            {
                                people.Add(_MapDataReaderToPerson(reader, ordPersonID, ordNationalNo, ordFirstName, ordSecondName, ordThirdName, ordLastName, ordDateOfBirth, ordGender, ordAddress, ordPhone, ordEmail, ordNationalityCountryID,ordImagePath ));
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
