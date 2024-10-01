

namespace Docket_Eagle.Repositories
{
    public class MongoDbSettings : IMongoDbSettings
    {
        private readonly IConfiguration _configuration;

        public MongoDbSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("ConnectionString");
        }
        public string GetDatabaseName()
        {
            return _configuration.GetValue<string>("DatabaseName");
        }


    }
}
