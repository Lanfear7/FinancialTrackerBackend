using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
using FinancialTracker.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinancialTracker.Repositories
{
    public class TrackerRepository : ITrackerRepository
    {
        private readonly DataContext _context;

        public TrackerRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TrackerTransactionsModel> GetUsersTrackers(int userId)
        {
            var trackerTransactions = (from tracker in _context.Trackers
                                       where tracker.User.Id == userId
                                       join transaction in _context.Transactions
                                       on tracker.Id equals transaction.Tracker.Id into tt
                                       from subTransaction in tt.DefaultIfEmpty()
                                       select new TrackerTransactionsModel
                                       {
                                           Tracker = tracker,
                                           Transaction = subTransaction
                                       }).ToList();

            if (trackerTransactions.Count == 0)
            {
                
                return null;
            }
            return trackerTransactions;
        }

        public int AddTracker(string Name, int Id)
        {
            var addTracker = new Tracker
            {
                Name = Name,
                UserId = Id
            };
            try
            {
                _context.Trackers.Add(addTracker);
                _context.SaveChanges();
                var TrackerId = addTracker.Id;
                return TrackerId;
            }
            catch (Exception error)
            {

            }
            return 0;
        }

        public bool AddTransactions(ICollection<TransactionDTO> request, int Id)
        {
            foreach(var userTransaction in request)
            {
                var transaction = new Transaction
                {
                    Amount = userTransaction.Amount,
                    DateTime = userTransaction.DateTime,
                    TrackerId = Id
                };
                try
                {
                    _context.Transactions.Add(transaction);
                    _context.SaveChanges();
                }
                catch(Exception error)
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteTracker(int Id)
        {
            var remove = (from tracker in _context.Trackers
                          where tracker.Id == Id
                          select tracker).FirstOrDefault();
            try
            {
                _context.Trackers.Remove(remove);
                _context.SaveChanges();
            }catch(Exception error)
            {
                return false;
            }
            return true;
        }

    }
}
