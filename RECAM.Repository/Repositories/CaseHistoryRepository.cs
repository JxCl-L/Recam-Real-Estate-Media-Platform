using MongoDB.Driver;
using RECAM.DataAccess.Data;
using RECAM.Models.Logs;
using RECAM.Repository.Interfaces;

namespace RECAM.Repository.Repositories;

public class CaseHistoryRepository : ICaseHistoryRepository
{
    private readonly IMongoCollection<CaseHistory> _collection;

    public CaseHistoryRepository(MongoDbContext mongoDbContext)
    {
        _collection = mongoDbContext.GetCollection<CaseHistory>("case_history");
    }

    public Task InsertAsync(CaseHistory caseHistory)
    {
        return _collection.InsertOneAsync(caseHistory);
    }
}
