using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
namespace DVLD.DAL.Repo.ADONet
{
    public class PersonRepositoryADO : IPersonRepository
    {
        public async Task<int> AddAsync(Person PersonDetails)
        {
            string Query = @"INSERT INTO People 
        (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
        VALUES 
        (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
        SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new(Query);

            Command.Parameters.AddWithValue("@NationalNo", PersonDetails.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", PersonDetails.FirstName);
            Command.Parameters.AddWithValue("@SecondName", PersonDetails.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(PersonDetails.ThirdName) ? (object)DBNull.Value : PersonDetails.ThirdName);
            Command.Parameters.AddWithValue("@LastName", PersonDetails.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", PersonDetails.DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", (byte)PersonDetails.Gendor);
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
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@PersonID", (object)PersonID);
            Person person = new();

            return await DbExecutor.ExecuteReaderSingleAsync<Person, PersonColumnIndices>(Command, PersonMapper.FromReader);
        }
        public async Task<PersonDeletionResult> DeleteAsync(int PersonID)
        {
            string Query = @"
                IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
                BEGIN
                    SELECT 0;
                    RETURN;
                END

                IF EXISTS (SELECT 1 FROM Users WHERE PersonID = @PersonID)
                BEGIN
                    SELECT -1;
                    RETURN;
                END

                IF EXISTS (SELECT 1 FROM Applications WHERE ApplicantPersonID = @PersonID)
                BEGIN
                    SELECT -2;
                    RETURN;
                END

                IF EXISTS (SELECT 1 FROM Drivers WHERE PersonID = @PersonID)
                BEGIN
                    SELECT -3;
                    RETURN;
                END

                DELETE FROM People WHERE PersonID = @PersonID;
                SELECT 1;"; 
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue($"@PersonID", (object)PersonID);
            PersonDeletionResult enResult = (PersonDeletionResult)await DbExecutor.ExecuteScalarReturnInt(Command);
            return enResult;
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
                Gendor=@Gendor,
                Address=@Address,
                Phone=@Phone,
                Email=@Email,
                NationalityCountryID=@NationalityCountryID,
                ImagePath=@ImagePath
                WHERE PersonID=@PersonID";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@PersonID", UpdatedPerson.PersonID);
            Command.Parameters.AddWithValue("@NationalNo", UpdatedPerson.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", UpdatedPerson.FirstName);
            Command.Parameters.AddWithValue("@SecondName", UpdatedPerson.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(UpdatedPerson.ThirdName) ? (object)DBNull.Value : UpdatedPerson.ThirdName);
            Command.Parameters.AddWithValue("@LastName", UpdatedPerson.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", UpdatedPerson.DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", (byte)UpdatedPerson.Gendor);
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
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue($"@PersonID", PersonID);
            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public async Task<Person?> FindByNationalNoAsync(string NationalNo)
        {
            string Query = $"SELECT TOP 1 * FROM People_View WHERE NationalNo = @NationalNo";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue("@NationalNo", (object)NationalNo);
            Person person = new();

            return await DbExecutor.ExecuteReaderSingleAsync<Person, PersonColumnIndices>(Command, PersonMapper.FromReader);
        }
        public async Task<PersonDeletionResult> DeleteByNationalNoAsync(string NationalNo)
        {
            string Query = @"
                DECLARE @PersonID INT;

                SELECT @PersonID = PersonID 
                FROM People 
                WHERE NationalNo = @NationalNo;

                IF @PersonID IS NULL
                BEGIN
                    SELECT 0;
                    RETURN;
                END

                IF EXISTS (SELECT 1 FROM Users WHERE PersonID = @PersonID)
                BEGIN
                    SELECT -1;
                    RETURN;
                END

                IF EXISTS (SELECT 1 FROM Applications WHERE ApplicantPersonID = @PersonID)
                BEGIN
                    SELECT -2;
                    RETURN;
                END

                IF EXISTS (SELECT 1 FROM Drivers WHERE PersonID = @PersonID)
                BEGIN
                    SELECT -3;
                    RETURN;
                END

                DELETE FROM People WHERE PersonID = @PersonID;
                SELECT 1;";
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue($"@NationalNo", (object)NationalNo);
            int result = await DbExecutor.ExecuteScalarReturnInt(Command);
            return (PersonDeletionResult)result;
        }
        public async Task<bool> UpdateByNationalNoAsync(Person UpdatedPerson)
        {
            string Query = $@"UPDATE People SET 
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
            SqlCommand Command;
            using (Command = new SqlCommand(Query))
            {
                Command.Parameters.AddWithValue("@NationalNo", UpdatedPerson.NationalNo);
                Command.Parameters.AddWithValue("@FirstName", UpdatedPerson.FirstName);
                Command.Parameters.AddWithValue("@SecondName", UpdatedPerson.SecondName);
                Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(UpdatedPerson.ThirdName) ? (object)DBNull.Value : UpdatedPerson.ThirdName);
                Command.Parameters.AddWithValue("@LastName", UpdatedPerson.LastName);
                Command.Parameters.AddWithValue("@DateOfBirth", UpdatedPerson.DateOfBirth);
                Command.Parameters.AddWithValue("@Gendor", (byte)UpdatedPerson.Gendor);
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
            SqlCommand Command = new(Query);
            Command.Parameters.AddWithValue($"@NationalNo", NationalNo);
            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }
        public async Task<int> CountAsync()
        {
            SqlCommand Command = new() {
                CommandText = $@"SELECT COUNT(*) AS PeopleCount FROM People"
            };
            return await DbExecutor.ExecuteScalarReturnInt(Command);
        }
        public async Task<List<Person>> GetAllAsync()
        { 
            string Query = "SELECT * FROM People_View";
            SqlCommand Command = new(Query);
            return await DbExecutor.ExecuteReaderListAsync<Person, PersonColumnIndices>(Command, PersonMapper.FromReader);
        }
        public async Task<bool> ExistsByNationalityCountryIDAsync(int NationalityCountryID)
        {
            SqlCommand Command = new() {
                CommandText = "Select 1 from People where NationalityCountryID = @NationalityCountryID"
            };
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            return await DbExecutor.ExecuteCommandReturnBoolean(Command);
        }


    }
}
