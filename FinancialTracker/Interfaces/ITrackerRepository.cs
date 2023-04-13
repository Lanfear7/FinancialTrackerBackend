using FinancialTracker.Models;
using FinancialTracker.Models.DTO;

namespace FinancialTracker.Interfaces
{
    public interface ITrackerRepository
    {
        public IEnumerable<TrackerTransactionsModel> GetUsersTrackers(int userId);
        public int AddTracker(string Name, int Id);
        public bool AddTransactions(ICollection<TransactionDTO> request, int Id);
        public bool AddTransactions(TransactionDTO request);
        public bool DeleteTracker(int Id);
    }
}
