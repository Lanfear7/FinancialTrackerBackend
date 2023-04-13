using FinacialTrackerApplication.Models;

namespace FinancialTracker.Models
{
    public class TrackerTransactionsModel
    {
        public Tracker Tracker { get; set; }
        public Transaction Transaction { get; set; }
    }
}
