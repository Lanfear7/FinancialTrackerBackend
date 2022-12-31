using FinacialTrackerApplication.Models;
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

        public static User user = new User();

        public AuthController(IAuthRepository AuthRepository)
        {
            _IAuthRepository = AuthRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterModel request)
        {
            _IAuthRepository.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.User_Name = request.Username;
            user.PasswordSalt = passwordSalt;
            user.Password = passwordHash;

            return Ok(user);
        }

    }
}
