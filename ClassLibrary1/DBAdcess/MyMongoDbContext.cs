using MongoDB.Driver;
using SeeMeDataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace SeeMeDataAccess.DBAdcess;

public class MyMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MyMongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    public MyMongoDbContext(IConfiguration configuration)
    {
        // Read the connection string and database name from configuration
        var connectionString = configuration.GetConnectionString("MongoDB");
        var databaseName = configuration.GetConnectionString("DatabaseName");

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    public IMongoCollection<User> Users =>
        _database.GetCollection<User>("Users");
}
