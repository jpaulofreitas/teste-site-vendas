using System;
using System.Security.Cryptography;
using System.Text;

namespace Aula2.Store.Domain.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            var salt = "34C3290412914FC1A46EAD9D4FFAB72A3FC379BF0DD94620BB6F220862EF8DA4";

            var arrayBytes = Encoding.UTF8.GetBytes(senha + salt);

            byte[] hashBytes;

            using (var sha = SHA512.Create())
            {
                hashBytes = sha.ComputeHash(arrayBytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }
}
