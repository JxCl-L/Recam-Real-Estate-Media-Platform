using RECAM.Models.Logs;

namespace RECAM.Repository.Interfaces;

public interface IUserActivityLogRepository
{
    Task InsertAsync(UserActivityLog userActivityLog);
}
