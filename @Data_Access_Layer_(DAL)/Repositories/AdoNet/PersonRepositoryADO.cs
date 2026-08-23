using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
namespace DVLD.DAL.Repo.ADONet
{
    public class PersonRepositoryADO : IPersonRepository
    {
        public async Task<int> AddAsync(Person PersonDetails)
        {
            string Query = @"INSERT INTO People 
        (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
        VALUES 
        (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
        SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query);

            Command.Parameters.AddWithValue("@NationalNo", PersonDetails.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", PersonDetails.FirstName);
            Command.Parameters.AddWithValue("@SecondName", PersonDetails.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(PersonDetails.ThirdName) ? (object)DBNull.Value : PersonDetails.ThirdName);
            Command.Parameters.AddWithValue("@LastName", PersonDetails.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", PersonDetails.DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", (byte)PersonDetails.Gender);
            Command.Parameters.AddWithValue("@Address", PersonDetails.Address);
            Command.Parameters.AddWithValue("@Phone", PersonDetails.Phone);
            Command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(PersonDetails.Email) ? (object)DBNull.Value : PersonDetails.Email);
            Command.Parameters.AddWithValue("@NationalityCountryID", PersonDetails.NationalityCountryID);
            Command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(PersonDetails.ImagePath) ? (object)DBNull.Value : PersonDetails.ImagePath);

            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public async Task<Person?> FindAsync(int PersonID)
        {
            string Query = "SELECT * From People_View where PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)PersonID);
            Person person = new Person();

            return await DbExecutor.ExecuteReaderSingleAsync<Person, PersonColumnIndices>(Command, PersonMapper.FromReader);
        }
        public async Task<bool> DeleteAsync(int PersonID)
        {
            string Query = $"DELETE FROM People WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@PersonID", (object)PersonID);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> UpdateAsync(Person UpdatedPerson)
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
            Command.Parameters.AddWithValue("@PersonID", UpdatedPerson.PersonID);
            Command.Parameters.AddWithValue("@NationalNo", UpdatedPerson.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", UpdatedPerson.FirstName);
            Command.Parameters.AddWithValue("@SecondName", UpdatedPerson.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(UpdatedPerson.ThirdName) ? (object)DBNull.Value : UpdatedPerson.ThirdName);
            Command.Parameters.AddWithValue("@LastName", UpdatedPerson.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", UpdatedPerson.DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", (byte)UpdatedPerson.Gender);
            Command.Parameters.AddWithValue("@Address", UpdatedPerson.Address);
            Command.Parameters.AddWithValue("@Phone", UpdatedPerson.Phone);
            Command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(UpdatedPerson.Email) ? (object)DBNull.Value : UpdatedPerson.Email);
            Command.Parameters.AddWithValue("@NationalityCountryID", UpdatedPerson.NationalityCountryID);
            Command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(UpdatedPerson.ImagePath) ? (object)DBNull.Value : UpdatedPerson.ImagePath);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> ExistsAsync(int PersonID)
        {
            string Query = $"SELECT 1 FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@PersonID", PersonID);
            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public async Task<Person?> FindByNationalNoAsync(string NationalNo)
        {
            string Query = $"SELECT TOP 1 * FROM People_View WHERE NationalNo = @NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue("@NationalNo", (object)NationalNo);
            Person person = new Person();

            return await DbExecutor.ExecuteReaderSingleAsync<Person, PersonColumnIndices>(Command, PersonMapper.FromReader);
        }
        public async Task<bool> DeleteByNationalNoAsync(string NationalNo)
        {
            string Query = $"DELETE FROM People WHERE NationalNo=@NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@NationalNo", (object)NationalNo);
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> UpdateByNationalNoAsync(Person UpdatedPerson)
        {
            string Query = $@"UPDATE People SET 
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
            SqlCommand Command;
            using (Command = new SqlCommand(Query))
            {
                Command.Parameters.AddWithValue("@NationalNo", UpdatedPerson.NationalNo);
                Command.Parameters.AddWithValue("@FirstName", UpdatedPerson.FirstName);
                Command.Parameters.AddWithValue("@SecondName", UpdatedPerson.SecondName);
                Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(UpdatedPerson.ThirdName) ? (object)DBNull.Value : UpdatedPerson.ThirdName);
                Command.Parameters.AddWithValue("@LastName", UpdatedPerson.LastName);
                Command.Parameters.AddWithValue("@DateOfBirth", UpdatedPerson.DateOfBirth);
                Command.Parameters.AddWithValue("@Gender", (byte)UpdatedPerson.Gender);
                Command.Parameters.AddWithValue("@Address", UpdatedPerson.Address);
                Command.Parameters.AddWithValue("@Phone", UpdatedPerson.Phone);
                Command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(UpdatedPerson.Email) ? (object)DBNull.Value : UpdatedPerson.Email);
                Command.Parameters.AddWithValue("@NationalityCountryID", UpdatedPerson.NationalityCountryID);
                Command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(UpdatedPerson.ImagePath) ? (object)DBNull.Value : UpdatedPerson.ImagePath);
            }
            return await DbExecutor.ExecuteCommandReturnRowsAffected(Command) > 0;
        }
        public async Task<bool> ExistsByNationalNoAsync(string NationalNo)
        {
            string Query = $"SELECT 1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand Command = new SqlCommand(Query);
            Command.Parameters.AddWithValue($"@NationalNo", NationalNo);
            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public async Task<int> CountAsync()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText =
            $@"SELECT COUNT(*) AS PeopleCount FROM People";
            
            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public async Task<List<Person>> GetAllAsync()
        { 
            string Query = "SELECT * FROM People_View";
            SqlCommand Command = new SqlCommand(Query);
            return await DbExecutor.ExecuteReaderListAsync<Person, PersonColumnIndices>(Command, PersonMapper.FromReader);
        }
}
    }
