using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;  


namespace FinacialTrackerApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IAuthRepository _IAuthRepository;

        public UserRepository(DataContext context, IAuthRepository IAuthRepository)
        {
            _context = context;
            _IAuthRepository = IAuthRepository;

        }

        public ICollection<User> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        //Method OverLoads************************

        public ICollection<User> GetUserByEmail(UserRegisterModel request)
        {
            var user = _context.Users.Where(u => u.Email == request.Email).ToList();
            if (user.Count == 0)
            {
                return user = null;
            }
            return user;
        }
        public ICollection<User> GetUserByEmail(UserLoginModel request)
        {
            var user = _context.Users.Where(u => u.Email == request.Email).ToList();
            if (user.Count == 0)
            {
                return user = null;
            }
            return user;
        }

        //*****************************************

        public bool AddUser(UserRegisterModel request)
        {
            User user = new User();
            _IAuthRepository.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.User_Name = request.Username;
            user.Email = request.Email;
            user.PasswordSalt = passwordSalt;
            user.Password = passwordHash;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public IEnumerable<UserTableJoin> GetUserById(int userId)
        {
            var user = _context.Users.Where(user => user.Id == userId).ToList();
            var entryPoint = (from u in _context.Users
                              join t in _context.Trackers on u.Id equals t.User.Id
                              where t.Id == u.Id
                              select new UserTableJoin
                              {
                                  User = u,
                                  Tracker = t,
                              }).ToList();
            /*if (entryPoint)
            {
                return  null;
            }*/ 
            return entryPoint;
        }

        public IEnumerable<User> UpdateMonthlyIncome(int userId, float income)
        {
            var userIncome = _context.Users.Where(user => user.Id == userId).FirstOrDefault();
            if (userIncome == null)
            {
                return null;
            }
            userIncome.MonthlyIncome = income;
            _context.SaveChanges();
            return _context.Users.Where(user => user.Id == userId).ToList();
        }


    }
}
