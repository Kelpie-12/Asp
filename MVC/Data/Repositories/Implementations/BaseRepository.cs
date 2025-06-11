using Microsoft.Data.SqlClient;

namespace MVC.Data.Repositories.Implementations
{
    public class BaseRepository
    {
        private static readonly string DEFAULT_CONNECTION_STRING = "Default";
        private static readonly string TEST_CONNECTION_STRING = "Test";
        private readonly string _connectionSttring;
        public BaseRepository(IConfiguration configuration)
        {
            string ?defaultConnectionString = configuration.GetConnectionString(TEST_CONNECTION_STRING);
            if (defaultConnectionString==null)
            {
                throw new Exception("Ошибка с строкой подключения");
            }
            _connectionSttring = defaultConnectionString;
        }
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionSttring);
        }
    }
}
