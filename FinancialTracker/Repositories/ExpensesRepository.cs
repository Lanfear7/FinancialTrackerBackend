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

        public IEnumerable<Expenses> GetAllExpenses(int Id)
        {
            var expenses = _context.Expenses.Where(e => e.UserId == Id).ToList();
            if(expenses.Count == 0)
            {
                return null;
            }
            return expenses;
        }

        public bool AddExpenses(ExpensesDTO request)
        {
            var expense = new Expenses();
            expense.ExpenseName = request.ExpenseName;
            expense.Value = request.Value;
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
