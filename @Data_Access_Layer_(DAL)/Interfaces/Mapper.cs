using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DAL.Interfaces
{
    internal interface IMapper<TEntity> where TEntity : class
    {
        TEntity MapReader(SqlDataReader reader);
    }
}
