using MongoDB.Driver;
using RECAM.DataAccess.Data;
using RECAM.Models.Logs;
using RECAM.Repository.Interfaces;

namespace RECAM.Repository.Repositories;

public class UserActivityLogRepository : IUserActivityLogRepository
{
    private readonly IMongoCollection<UserActivityLog> _collection;

    public UserActivityLogRepository(MongoDbContext mongoDbContext)
    {
        _collection = mongoDbContext.GetCollection<UserActivityLog>("user_activity_log");
    }

    public Task InsertAsync(UserActivityLog log)
    {
        return _collection.InsertOneAsync(log);
    }

}
