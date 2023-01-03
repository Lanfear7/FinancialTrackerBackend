using FinacialTrackerApplication.Models;

namespace FinancialTracker.Interfaces
{
    public interface IAuthRepository
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyUserPassword(string requestPassword, byte[] userPassword, byte[] userPasswordSalt);
        public string CreateJWT(User user);
    }
}
