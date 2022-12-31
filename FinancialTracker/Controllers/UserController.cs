using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinacialTrackerApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinacialTrackerApplication.Controllers
{
    [Route("FTAPI/users")]
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
            return _IUserRepository.GetUsers();
        }
    }

}
