using FinacialTrackerApplication.Models;

namespace FinacialTrackerApplication.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

    }
}
