using FinacialTrackerApplication.Interfaces;
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

        public DashboardController(IUserRepository iUserRepository)
        {
            _IUserRepository = iUserRepository;
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
            return Ok(user);
        }


        //********** TRACKERS **********

        
        [HttpGet, Authorize]
        [Route("CurrentUser/Trackers/{Id:int}")]
         public IActionResult CurrentUserTrackers(int Id)
        {
            var user = _IUserRepository.GetUsersTrackers(Id);
            if (user == null)
            {
                return BadRequest("Error User Not Found");
            }
            return Ok(user);
        }

    }
}
