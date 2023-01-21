using FinacialTrackerApplication.Data;
using FinancialTracker.Interfaces;

namespace FinancialTracker.Repositories
{
    public class ExpensesRepositoy : IExpensesRepositoy
    {
        private readonly DataContext _context;
        private readonly IExpensesRepositoy _IExpensesRepositoy;
        public ExpensesRepositoy(DataContext context, IExpensesRepositoy iExpensesRepositoy)
        {
            _context = context;
            _IExpensesRepositoy = iExpensesRepositoy;
        }

    }
}
