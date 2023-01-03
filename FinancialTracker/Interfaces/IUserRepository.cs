using FinacialTrackerApplication.Models;
using FinancialTracker.Models;

namespace FinacialTrackerApplication.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        ICollection<User> GetUserByEmail(UserLoginModel user);
        public bool AddUser(UserRegisterModel user);

    }
}
