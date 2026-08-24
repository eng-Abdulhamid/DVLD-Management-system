using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class PersonMapper
    {
        public async static Task<Person> FromReader(SqlDataReader reader, PersonColumnIndices indices)
        {
            try
            {
                return new Person
                {
                    PersonID = reader.GetInt32(indices.PersonId),
                    NationalNo = reader.GetString(indices.NationalNo),
                    FirstName = reader.GetString(indices.FirstName),
                    SecondName = reader.GetString(indices.SecondName),
                    ThirdName = reader.IsDBNull(indices.ThirdName) ? string.Empty : reader.GetString(indices.ThirdName),
                    LastName = reader.GetString(indices.LastName),
                    DateOfBirth = reader.GetDateTime(indices.DateOfBirth),
                    Gender = (byte)reader.GetValue(indices.Gender) == 0 ? Enums.Gender.Male : Enums.Gender.Female,
                    Address = reader.GetString(indices.Address),
                    Phone = reader.GetString(indices.Phone),
                    Email = reader.IsDBNull(indices.Email) ? string.Empty : reader.GetString(indices.Email),
                    NationalityCountryID = reader.GetInt32(indices.CountryId),
                    ImagePath = reader.IsDBNull(indices.ImagePath) ? string.Empty : reader.GetString(indices.ImagePath),
                    CountryName = reader.IsDBNull(indices.CountryName) ? string.Empty : reader.GetString(indices.CountryName)
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new Person();
            }
        }
    }
}