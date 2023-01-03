using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinacialTrackerApplication.Repositories;
using FinancialTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinacialTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _IUserRepository;

        public UserController(IUserRepository UserRepository)
        {
            _IUserRepository = UserRepository;
        }
        
        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _IUserRepository.GetAllUsers();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUsers(UserRegisterModel request)
        {
            var user = _IUserRepository.AddUser(request);
            if (!user)
            {
                return BadRequest("Unable to create user");
            }
            return Ok("User was created");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(UserLoginModel request)
        {
            var checkUser = _IUserRepository.GetUserByEmail(request);
            if(checkUser == null)
            {
                return BadRequest("Email not found");
            }
            return Ok(checkUser);
        }
    }

}
