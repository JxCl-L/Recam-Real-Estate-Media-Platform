using RECAM.Models.Logs;

namespace RECAM.Repository.Interfaces;

public interface ICaseHistoryRepository
{
    Task InsertAsync(CaseHistory caseHistory);
}
