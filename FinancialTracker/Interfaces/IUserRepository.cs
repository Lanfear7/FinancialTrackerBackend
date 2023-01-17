using FinacialTrackerApplication.Models;
using FinancialTracker.Models;

namespace FinacialTrackerApplication.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        ICollection<User> GetUserByEmail(UserLoginModel user);
        ICollection<User> GetUserByEmail(UserRegisterModel request);
        public bool AddUser(UserRegisterModel user);
       
    }
}
