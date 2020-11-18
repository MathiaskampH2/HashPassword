using System;
using System.Security.Cryptography;
using System.Text;

namespace HashPassword
{
    public class Hash
    {
        // kunne ikke få valideringen til at virke med salt
        // så denne bruges ikke
        public string GenerateSalt(int size)
        {

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] number = new byte[size];
            rng.GetBytes(number);

            return Convert.ToBase64String(number);
        }


        public string GenerateHash(string pwd)
        {
            

            byte[] bytes = Encoding.UTF8.GetBytes(pwd);

            SHA256Managed sha256Managed = new SHA256Managed();
            byte[] hashBytes = sha256Managed.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public string GenerateSha256Password(string pwd)
        {
            string password = pwd;
            string hashedPassword = GenerateHash(password);

            return hashedPassword;
        }
    }
}
