using System;
using System.Security.Cryptography;
using System.Text;

namespace KTPay.Helpers {
    
    public class KTPayHelper {
        
        public static string HashPassword(string password) {
        
            SHA1 sha = new SHA1CryptoServiceProvider();
            string hashPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashPassword;
        }
    
        public static string ComputeHash(string data, string key) {
        
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            HMACSHA512 hashString = new HMACSHA512(Encoding.UTF8.GetBytes(key));
            byte[] hashX = hashString.ComputeHash(bytes);
            string hash = Convert.ToBase64String(hashX);
            return hash;
        }
    }
}