namespace Docket_Eagle.Repositories
{
    public interface IMongoDbSettings
    {
        string GetConnectionString();
        string GetDatabaseName();
    }
}