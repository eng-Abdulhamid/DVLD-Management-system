using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DVLD.DAL.Mappers
{
    public class UsersColumnIndices : IColumnIndices<UsersColumnIndices>
    {
        public int UserID { get; init; }
        public int PersonID { get; init; }
        public int UserName { get; init; } 
        public int Password { get; init; }
        public int IsActive { get; init; }

        public static UsersColumnIndices Create(SqlDataReader reader)
        {
            return new UsersColumnIndices
            {
                UserID = reader.GetOrdinal("UserID"),
                PersonID = reader.GetOrdinal("PersonID"),
                UserName = reader.GetOrdinal("UserName"),
                Password = reader.GetOrdinal("Password"),
                IsActive = reader.GetOrdinal("IsActive")
            };
        }

    }
}
