using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public interface IColumnIndices<TColumnIndices>
    {
        public static abstract TColumnIndices Create(SqlDataReader reader);
    }
    public class PersonColumnIndices : IColumnIndices<PersonColumnIndices>
    {
        public int PersonId { get; init; }
        public int NationalNo { get; init; }
        public int FirstName { get; init; }
        public int SecondName { get; init; }
        public int ThirdName { get; init; }
        public int LastName { get; init; }
        public int DateOfBirth { get; init; }
        public int Gendor { get; init; }
        public int Address { get; init; }
        public int Phone { get; init; }
        public int Email { get; init; }
        public int CountryId { get; init; }
        public int ImagePath { get; init; }
        public int CountryName { get; init; }

        public static PersonColumnIndices Create(SqlDataReader reader)
        {
            return new PersonColumnIndices
            {
                PersonId = reader.GetOrdinal("PersonID"),
                NationalNo = reader.GetOrdinal("NationalNo"),
                FirstName = reader.GetOrdinal("FirstName"),
                SecondName = reader.GetOrdinal("SecondName"),
                ThirdName = reader.GetOrdinal("ThirdName"),
                LastName = reader.GetOrdinal("LastName"),
                DateOfBirth = reader.GetOrdinal("DateOfBirth"),
                Gendor = reader.GetOrdinal("Gendor"),
                Address = reader.GetOrdinal("Address"),
                Phone = reader.GetOrdinal("Phone"),
                Email = reader.GetOrdinal("Email"),
                CountryId = reader.GetOrdinal("NationalityCountryID"),
                ImagePath = reader.GetOrdinal("ImagePath"),
                CountryName = reader.GetOrdinal("CountryName")
            };
        }
    }
}