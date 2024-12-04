using MySql.Data.MySqlClient;

namespace DemoApi.Context
{
    public class DapperConnection
    {
        private readonly string _connectionString;

        public DapperConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DemoDatabase");
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
