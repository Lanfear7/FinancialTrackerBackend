using FinancialTracker.Models;
using FinancialTracker.Models.DTO;

namespace FinancialTracker.Interfaces
{
    public interface IExpensesRepository
    {
        public bool AddExpenses(ExpensesDTO request);
    }
}
