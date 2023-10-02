using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cssteamscraping
{
    internal class Database
    {
        static readonly MySqlConnectionStringBuilder mySqlConnection = new()
        {
            Server = "localhost",
            UserID = "user",
            Password = "password",
            Database = "cssteamscraping",
            Pooling = true
        };

        public static MySqlConnection CreateConnection() => new(mySqlConnection.ConnectionString);
    }
}
