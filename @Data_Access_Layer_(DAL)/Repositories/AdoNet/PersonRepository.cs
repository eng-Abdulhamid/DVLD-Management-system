using DVLD.DAL.Common;
using DVLD.DAL.Interfaces;
using DVLD.DAL.Repo.ADOnet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DVLD.DAL.Entities;

namespace DVLD.DAL.Repo.ADONet
{
    public class PersonRepository : IPersonRepository
    {
        public int Add(Person PersonDeatils)
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
            return DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public Person Find(int PersonID)
        {
            string Query = "SELECT * From People_View where People.PersonID = @PersonID";
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
                            if (reader.Read())
                            {
                                Mapper.PersonMapper.PersonColumnIndices indices = Mapper.PersonMapper.PersonColumnIndices.Create(reader);
                                person = Mapper.PersonMapper.ToEntity(reader, indices);
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
        public bool Delete(int PersonID)
        {
            string Query = $"DELETE FROM People WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@PersonID", (object)PersonID);
            return DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public bool Update(Person UpdatedPerson)
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
            return DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public bool Exists(int PersonID)
        {
            string Query = $"SELECT 1 FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@PersonID", PersonID);
            return DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public Person FindByNationalNo(string NationalNo)
        {
            string Query = $"SELECT TOP 1 * FROM People_View WHERE NationalNo = @NationalNo";
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
                            if (reader.Read())
                            {
                                Mapper.PersonMapper.PersonColumnIndices indices = Mapper.PersonMapper.PersonColumnIndices.Create(reader);
                                person = Mapper.PersonMapper.ToEntity(reader, indices);
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
        public bool DeleteByNationalNo(string NationalNo)
        {
            string Query = $"DELETE FROM People WHERE NationalNo=@NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@NationalNo", (object)NationalNo);
            return DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public bool UpdateByNationalNo(Person UpdatedPerson)
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
            return DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public bool ExistsByNationalNo(string NationalNo)
        {
            string Query = $"SELECT 1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@NationalNo", NationalNo);
            return DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public int Count()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText =
            $@"SELECT COUNT(*) AS PeopleCount FROM People";
            
            return DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public List<Person> GetAll()
        { 
            string Query = "SELECT * FROM People_View";
            SqlCommand Command = new SqlCommand(Query);
            return _ExecuteReaderList(Command);
        }
        private static List<Person> _ExecuteReaderList(SqlCommand command)
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                command.Connection = connection;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Mapper.PersonMapper.PersonColumnIndices indices = Mapper.PersonMapper.PersonColumnIndices.Create(reader);
                            while (reader.Read())
                            {
                                people.Add(Mapper.PersonMapper.ToEntity(reader, indices));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    people.Clear();
                    Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] - Error message: {ex.Message}");
                }
            }

            return people;
        }
    }
}
