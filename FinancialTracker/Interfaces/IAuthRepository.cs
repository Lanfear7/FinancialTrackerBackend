namespace FinancialTracker.Interfaces
{
    public interface IAuthRepository
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
