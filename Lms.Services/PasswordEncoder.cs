namespace Lms.Services
{
    public class PasswordEncoder
    {
        public bool VerifyPassword(string hash, string plainPassword) => BCrypt.Net.BCrypt.Verify(plainPassword, hash);
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    }
}