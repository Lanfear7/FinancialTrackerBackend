using FinacialTrackerApplication.Models;
using FinancialTracker.Models;

namespace FinacialTrackerApplication.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetAllUsers();
        public ICollection<User> GetUserByEmail(UserLoginModel user);
        public ICollection<User> GetUserByEmail(UserRegisterModel request);
        public bool AddUser(UserRegisterModel user);
       
    }
}
