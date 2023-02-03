using FinacialTrackerApplication.Interfaces;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
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

        public DashboardController(IUserRepository iUserRepository, ITrackerRepository iTrackerRepository)
        {
            _IUserRepository = iUserRepository;
            _ITrackerRepository = iTrackerRepository;
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

            if (request.Transactions.Count > 0)
            {
                //add to db with returned tracker id
            }
            //
            return Ok();
        }

    }
}
