using MySql.Data.MySqlClient;

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
