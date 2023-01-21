using FinacialTrackerApplication.Models;
using FinancialTracker.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FinancialTracker.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
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

        public string CreateJWT(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.User_Name),
                new Claim(ClaimTypes.Role, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Keys:JwtToken").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var JWT = new JwtSecurityTokenHandler().WriteToken(token);

            return JWT;

        }


    }
}
