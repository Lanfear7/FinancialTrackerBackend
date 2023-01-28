using FinacialTrackerApplication.Models;

namespace FinancialTracker.Models
{
    public class UserTableJoin
    {
        public User User { get; set; }
        public Tracker Tracker { get; set; }
    }
}
