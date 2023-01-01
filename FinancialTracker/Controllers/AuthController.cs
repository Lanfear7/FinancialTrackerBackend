using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinacialTrackerApplication.Repositories;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FinancialTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _IAuthRepository;
        private readonly IUserRepository _IUserRepository;

        public static User user = new User();

        public AuthController(IAuthRepository AuthRepository, IUserRepository UserRepository)
        {
            _IAuthRepository = AuthRepository;
            _IUserRepository = UserRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterModel request)
        {
            var userAdded = _IUserRepository.AddUser(request);
            if (!userAdded)
            {
                return BadRequest("User Not Added");
            }

            return Ok("User Added");
        }

    }
}
