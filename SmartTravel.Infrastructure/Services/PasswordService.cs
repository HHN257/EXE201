using SmartTravel.Application.Services;
using System.Security.Cryptography;
using System.Text;

namespace SmartTravel.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public (string hash, string salt) HashPassword(string password)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Combine password and salt
            string passwordWithSalt = password + salt;
            
            // Hash the password with salt
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));
                string hash = Convert.ToBase64String(hashBytes);
                
                return (hash, salt);
            }
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            // Combine password and salt
            string passwordWithSalt = password + salt;
            
            // Hash the password with salt
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));
                string computedHash = Convert.ToBase64String(hashBytes);
                
                return computedHash == hash;
            }
        }
    }
}
