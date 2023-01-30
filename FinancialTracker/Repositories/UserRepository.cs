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

        public ICollection<User> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        //************************Method OverLoads***********************

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

        //****************************************************************

        public IEnumerable<User> GetUserById(int userId)
        {
            var userData = _context.Users.Where(u => u.Id == userId).ToList();
            if (userData.Count == 0)
            {
                return null;
            }
            return userData;
        }

        public IEnumerable<User> UpdateMonthlyIncome(int userId, float income)
        {
            var user = _context.Users.Where(user => user.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            user.MonthlyIncome = income;
            _context.SaveChanges();
            return _context.Users.Where(user => user.Id == userId).ToList();
        }

        public IEnumerable<TrackerTransactionsModel> GetUsersTrackers(int userId)
        {
            var trackerTransactions = (from tracker in _context.Trackers where tracker.User.Id == userId
                                       join transaction in _context.Transactions
                                       on tracker.User.Id equals transaction.User.Id
                                       select new TrackerTransactionsModel
                                       {
                                           Tracker = tracker,
                                           Transaction = transaction
                                       }).ToList();

            if(trackerTransactions.Count == 0)
            {
                return null;
            }
            return trackerTransactions;
        }
        
    }
}
