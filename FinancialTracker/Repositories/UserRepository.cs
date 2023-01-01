using Azure.Core;
using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Interfaces;
using FinacialTrackerApplication.Models;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;

namespace FinacialTrackerApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IAuthRepository _IAuthRepository;

        public static User user = new User();

        public UserRepository(DataContext context, IAuthRepository IAuthRepository)
        {
            _context = context;
            _IAuthRepository = IAuthRepository;

        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public bool AddUser(UserRegisterModel request)
        {
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
                return false;
            }
            
        }


    }
}
