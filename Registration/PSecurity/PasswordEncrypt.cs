using System.Security.Cryptography;
using System.Text;

namespace Registration.PSecurity
{
    public class PasswordEncrypt
    {
        public static string EncryptText(string openText)
        {
            string hashedString = ComputeSha256Hash(openText);
            return hashedString;
        }

        static string ComputeSha256Hash(string openText)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                //Compute the hash. Returns byte array.
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(openText));

                //Convert byte array to String
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}