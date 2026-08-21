using System;
using System.Data.SqlClient;
using DVLD.DAL.Common;
using DVLD.DAL.Entities;

namespace DVLD.DAL.Mapper
{
    public static class PersonMapper
    {
        public struct PersonColumnIndices
        {
            public int PersonId;
            public int NationalNo;
            public int FirstName;
            public int SecondName;
            public int ThirdName;
            public int LastName;
            public int DateOfBirth;
            public int Gender;
            public int Address;
            public int Phone;
            public int Email;
            public int CountryId;
            public int ImagePath;
            public int CountryName;

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
                    Gender = reader.GetOrdinal("Gender"),
                    Address = reader.GetOrdinal("Address"),
                    Phone = reader.GetOrdinal("Phone"),
                    Email = reader.GetOrdinal("Email"),
                    CountryId = reader.GetOrdinal("NationalityCountryID"),
                    ImagePath = reader.GetOrdinal("ImagePath"),
                    CountryName = reader.GetOrdinal("CountryName")
                };
            }
        }
        public static Person ToEntity(SqlDataReader reader, PersonColumnIndices indices)
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
                    Gender = Convert.ToByte(reader.GetValue(indices.Gender)) == 1 ? Enums.enGender.Male : Enums.enGender.Female,
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
                Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return null;
            }
        }
    }
}