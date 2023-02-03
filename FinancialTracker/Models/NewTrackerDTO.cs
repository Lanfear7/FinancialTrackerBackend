using FinacialTrackerApplication.Models;
using FinancialTracker.Models.DTO;

namespace FinancialTracker.Models
{
    public class NewTrackerDTO
    {
        public string Name { get; set; }
        public ICollection<TransactionDTO>? Transactions { get; set; }
    }
}
