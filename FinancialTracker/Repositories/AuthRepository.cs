using FinacialTrackerApplication.Data;
using FinacialTrackerApplication.Models;
using FinancialTracker.Interfaces;
using FinancialTracker.Models;
using System.Security.Cryptography;

namespace FinancialTracker.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public AuthRepository(DataContext context)
        {
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyUserPassword(string requestPassword, byte[] userPassword, byte [] userPasswordSalt)
        {
            using(var hmac = new HMACSHA512(userPasswordSalt))
            {
                var checkPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(requestPassword));
                return checkPasswordHash.SequenceEqual(userPassword);
            }
        }


    }
}
