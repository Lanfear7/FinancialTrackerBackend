using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Models;
using FinancialTracker.Interfaces;
using FinancialTracker.Models.DTO;

namespace FinancialTracker.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {

        private readonly DataContext _context;

        public ExpensesRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddExpenses(ExpensesDTO request)
        {
            var expense = new Expenses();
            expense.ExpenseName = request.ExpenseName;
            expense.Value = request.Value;
            expense.Type = request.Type;
            expense.DateTime = request.DateTime;
            expense.UserId = request.UserId;
            try
            {
                _context.Add(expense);
                _context.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
            
        }

    }
}
