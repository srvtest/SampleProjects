using illumiyaFramework.Entities.Configurations;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace illumiyaFramework.Entities
{
    public class BaseRepository
    {
        public IDbConnection _db;

        public BaseRepository(IOptions<DBConnectionOptions> dbConnectionOptions)
        {
            _db = new MySqlConnection(dbConnectionOptions.Value.ConnectionString);
        }
    }
}
