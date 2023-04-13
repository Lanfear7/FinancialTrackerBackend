using FinacialTrackerApplication.Models;
using FinancialTracker.Models;
using FinancialTracker.Models.DTO;

namespace FinancialTracker.Interfaces
{
    public interface IExpensesRepository
    {
        public bool AddExpenses(ExpensesDTO request);
        public IEnumerable<Expenses> GetAllExpenses(int Id);
        public bool DeleteExpenses(int id);
    }
}
