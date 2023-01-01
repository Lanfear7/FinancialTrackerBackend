using FinacialTrackerApplication.Models;
using FinancialTracker.Models;

namespace FinacialTrackerApplication.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        public bool AddUser(UserRegisterModel user);

    }
}
