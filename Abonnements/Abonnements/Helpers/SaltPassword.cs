using Abonnements.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.Helper
{
    public static class SaltPassword
    {

        internal static byte[] GenerateSalt()
        {
            using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[Constant.SaltByteSize];
                saltGenerator.GetBytes(salt);
                return salt;
            }
        }

        internal static byte[] ComputeHash(string password, byte[] salt)
        {
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt, Constant.HashingIterationsCount))
            {
                return hashGenerator.GetBytes(Constant.HashByteSize);
            }
        }
        internal static string GetPasswordHash(string password)
        {
            byte[] salt = GenerateSalt();
            byte[] hash = ComputeHash(password, salt);
            byte[] hashBytes = new Byte[36]; //(16+20)
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);

        }
        internal static bool ComparePassword(string EmployePassword, string TextboxPassword)
        {
            /* Fetch the stored value */
            if (!string.IsNullOrEmpty(EmployePassword))
            {

                /* Extract the bytes */
                byte[] hashBytes = Convert.FromBase64String(EmployePassword);
                /* Get the salt */
                byte[] salt = new byte[Constant.SaltByteSize];
                Array.Copy(hashBytes, 0, salt, 0, Constant.SaltByteSize);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(TextboxPassword, salt, Constant.HashingIterationsCount);
                byte[] hash = pbkdf2.GetBytes(Constant.HashByteSize);
                /* Compare the results */
                for (int i = 0; i < Constant.HashByteSize; i++)
                    if (hashBytes[i + Constant.SaltByteSize] != hash[i])
                    {
                        return false;
                    }
                return true;
            }
            return false;
        }
    }
}
