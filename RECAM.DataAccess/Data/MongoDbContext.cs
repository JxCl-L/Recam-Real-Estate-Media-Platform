using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RECAM.DataAccess.Configurations;

namespace RECAM.DataAccess.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> options)
    {
        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);
}
