using FinacialTrackerApplication.Interfaces;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
using FinancialTracker.Models.DTO;
using FinancialTracker.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IUserRepository _IUserRepository;
        private readonly ITrackerRepository _ITrackerRepository;
        private readonly IExpensesRepository _IExpensesRepository;


        public DashboardController(
            IUserRepository iUserRepository, 
            ITrackerRepository iTrackerRepository,
            IExpensesRepository iExpensesRepository)
        {
            _IUserRepository = iUserRepository;
            _ITrackerRepository = iTrackerRepository;
            _IExpensesRepository = iExpensesRepository;
        }

        [HttpGet, Authorize]
        [Route("CurrentUser/{Id:int}")]
        public IActionResult CurrentUserData(int Id)
        {
            var user = _IUserRepository.GetUserById(Id);
            if (user == null)
            {
                return BadRequest("Error User Not Found");
            }
            return Ok(user);
        }
        
        [HttpPost, Authorize]
        [Route("CurrentUser/UpdateIncome/{Id:int}")]
        public IActionResult UpdateMonthlyIncome(int Id, IncomeDTO request )
        {            
            var user = _IUserRepository.UpdateMonthlyIncome(Id, request.Income);
            if(user == null)
            {
                BadRequest("Coult not update income");
            }
            return Ok("Income Updated");
        }


        //********** TRACKERS **********

        
        [HttpGet, Authorize]
        [Route("CurrentUser/Trackers/{Id:int}")]
         public IActionResult CurrentUserTrackers(int Id)
        {
            var user = _ITrackerRepository.GetUsersTrackers(Id);
            if (user == null)
            {
                return BadRequest("No Trackers Found");
            }
            return Ok(user);
        }

        [HttpPost, Authorize]
        [Route("CurrentUser/Trackers/Add/{Id:int}")]
        public IActionResult AddUserTracker(NewTrackerDTO request, int Id)
        {
            if(request.Name == "")
            {
                return BadRequest("Track Must Have a Name");
            }
            //add tracker to db must have tracker id returned
            var trackerName = request.Name;
            var addedTrackerId = _ITrackerRepository.AddTracker(trackerName, Id);
            if(addedTrackerId == 0)
            {
                return BadRequest("Tracker Was Not Added");
            }

            if (request.Transactions != null)
            {
                //add to db with returned tracker id
                var transactions = request.Transactions;
                var addedTransaction = _ITrackerRepository.AddTransactions(transactions, addedTrackerId);
                if (!addedTransaction)
                {
                    return BadRequest("Transaction's Were Not Added");
                }
                return Ok("Tracker Id:" + addedTrackerId + " Has Transactions");
            }
            //
            return Ok("Tracker Added");
        }
        [HttpDelete, Authorize]
        [Route("CurrentUser/Trackers/Delete/{Id:int}")]
        public IActionResult DeleteTracker(int Id)
        {
            var removeTracker = _ITrackerRepository.DeleteTracker(Id);
            if(removeTracker != true)
            {
                return BadRequest("Could not remove tracker");
            }
            return Ok();
        }


        [HttpPost, Authorize]
        [Route("CurrentUser/Transactions/Add")]
        public IActionResult AddTransaction(TransactionDTO request)
        {
            var addTransaction = _ITrackerRepository.AddTransactions(request);
            if(addTransaction != true)
            {
                return BadRequest("Couldnt add transaction");
            }
            return Ok();
        }

        [HttpPost, Authorize]
        [Route("CurrentUser/Expenses/Add")]
        public IActionResult AddExpenses(ExpensesDTO request)
        {
            var addExpense = _IExpensesRepository.AddExpenses(request);
            if(addExpense != true)
            {
                return BadRequest("Could not add expenses");
            }
            return Ok();
        }

    }
}
