using System.Security.Cryptography;

namespace Authentication.Services
{
    public class PasswordManager
    {
        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2Service = new Rfc2898DeriveBytes(password, salt, 100);
            var hash = pbkdf2Service.GetBytes(20);
            var hashBytes = new byte[36];

            Array.Copy(salt,0,hashBytes,0,16);
            Array.Copy(hash,0,hashBytes,16,20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
