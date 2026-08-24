using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using DVLD.DAL.Mappers;
using Microsoft.Data.SqlClient;

namespace DVLD.DAL.Mapper
{
    public static class UserMapper
    {
        public async static Task<User> FromReader(SqlDataReader reader, UsersColumnIndices indices)
        {
            try
            {
                return new User
                {
                    UserID = reader.GetInt32(indices.UserID),
                    PersonID = reader.GetInt32(indices.PersonID),
                    UserName = reader.GetString(indices.UserName),
                    Password = reader.GetString(indices.Password),
                    IsActive = reader.GetBoolean(indices.IsActive),
                };
            }
            catch (Exception ex)
            {
                await Logs.AppendLog(Logs.enType.Error, $"[{DateTime.Now}] Mapping error: {ex.Message}");
                return new();
            }
        }
    }
}