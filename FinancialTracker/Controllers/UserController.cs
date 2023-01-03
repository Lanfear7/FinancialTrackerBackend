using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinacialTrackerApplication.Repositories;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinacialTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IAuthRepository _IAuthRepository;

        public UserController(IUserRepository UserRepository, IAuthRepository AuthRepository)
        {
            _IUserRepository = UserRepository;
            _IAuthRepository = AuthRepository;
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
            var user = _IUserRepository.GetUserByEmail(request);
            if(user == null)
            {
                return BadRequest("Email not found");
            }
            if (!_IAuthRepository.VerifyUserPassword(request.Password, user.ToArray()[0].Password, user.ToArray()[0].PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            return Ok(user);
        }
    }

}
